
using BLL;
using DTO;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace UI
{

	public class ReservationController : Controller
	{
		private IReservationManager ReservationManager { get; }

		private IRoomManager RoomManager { get; }

		public ReservationController(IReservationManager reservationManager, IRoomManager roomManager)
		{
			ReservationManager = reservationManager;
			RoomManager = roomManager;
		}

		public IActionResult Cancel()
		{
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult DeleteReservation(DeleteReservationInputModel deleteReservationInformation)
		{
			if (!ModelState.IsValid)
			{
				TempData["ShowCancelError"] = 3;
				return View("Cancel");
			}

			var result = ReservationManager.DeleteReservation(deleteReservationInformation.ReservationToDeleteIdentification);

			if (result.Result.Value == 0)
			{
				TempData["ShowCancelError"] = 3;
				return View("Cancel");
			}

			if (result.Result.Value == 2)
			{
				TempData["ShowCancelError"] = 1;
				return View("Cancel");
			}


			TempData["ShowCancelError"] = 0;
			return View("Cancel");
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult ReserveRoomsFromBasket(ClientInformationModel clientInformation)
		{
			if (!ModelState.IsValid)
			{
				StringBuilder errorDescription = new StringBuilder();
				if (String.IsNullOrWhiteSpace(clientInformation.Firstname))
				{
					TempData["ShowBasketError"] = "Enter your firstname.";
					return RedirectToAction("ShowBasket", "Room");

				}
				if (String.IsNullOrWhiteSpace(clientInformation.LastName))
				{
					TempData["ShowBasketError"] = "Enter your lastname";
					return RedirectToAction("ShowBasket", "Room");
				}
				else
				{
					TempData["ShowBasketError"] = "Enter valid informations.";
					return RedirectToAction("ShowBasket", "Room");
				}
			}

			clientInformation.Firstname = clientInformation.Firstname.Replace(" ", string.Empty);
			clientInformation.LastName = clientInformation.LastName.Replace(" ", string.Empty);

			var temp = TempData.Peek("MyList");

			var reservations = new List<Reservation>();
			var roomToReserve = new List<Room>();

			if (temp != null)
			{
				var numberOfNight = ((DateTime)TempData.Peek("CheckOutDate")).Subtract((DateTime)TempData.Peek("CheckInDate"));
				var numberOfNightInt = numberOfNight.Days;

				foreach (var item in (int[])temp)
				{
					roomToReserve.Add(RoomManager.GetRoomWithId(item, (DateTime)TempData.Peek("CheckInDate"), (DateTime)TempData.Peek("CheckOutDate")).Result.Value);
				}

				foreach (var room in roomToReserve)
				{
					reservations.Add(ReservationManager.InsertReservation(clientInformation.Firstname, clientInformation.LastName, (DateTime)TempData.Peek("CheckInDate"), (DateTime)TempData.Peek("CheckOutDate"), 
						room.Price * numberOfNightInt, room.IdRoom).Result.Value);
				}

				TempData["MyList"] = null; 

				return View("ReservationSuccess", reservations);
			}
			else
			{
				TempData["ShowBasketError"] = "There is nothing on your basket.";
				return RedirectToAction("ShowBasket", "Room");
			}
		}
	}
}
