
using BLL;
using DTO;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UI
{
    public class RoomController : Controller
    {
        private IRoomManager RoomManager { get; }

        private IHotelManager HotelManager { get; }

        private IPictureManager PictureManager { get; }

        private static List<int> customerRoomsID = new List<int>();

        private static SearchRoomInputModel alreadySearched;

        private static SearchRoomInputModel defaultInformation;

        private static bool typeSortFlag = false;

        private static bool priceSortFlag = false;

        private static bool hotelSortFlag = false;

        private static int sortMethod = 0;

        public RoomController(IRoomManager roomManager, IHotelManager hotelManager, IPictureManager pictureManager)
        {
            RoomManager = roomManager;
            HotelManager = hotelManager;
            PictureManager = pictureManager;
        }

        public IActionResult Index()
        {
            var locationsAvailable = HotelManager.GetLocationsAvailable().Result.Value;
            var categoriesAvailable = HotelManager.GetCategoriesAvailable().Result.Value;
            var typesAvailable = RoomManager.GetTypesAvailable().Result.Value;
            var maximumPrice = RoomManager.GetMaximumPrice().Result.Value;
            maximumPrice = Math.Round(maximumPrice / 100, 0) * 100;

            defaultInformation = new SearchRoomInputModel()
            {
                PossibleLocations = locationsAvailable,
                PossibleCategories = categoriesAvailable,
                PossibleTypes = typesAvailable,
                MaxPrice = maximumPrice,
                HasWifi = true,
                HasParking = true,
                HasTV = true,
                HasHairDryer = true
            };

            return View(defaultInformation);
        }

        public IActionResult ReShowRooms()
        {
            return RedirectToAction("ShowRooms", alreadySearched);
        }

        public IActionResult ShowRooms(SearchRoomInputModel roomInformation)
        {
            StringBuilder roomIndexError = new StringBuilder();
            if (!VerifyInformationIntegrity(roomInformation, roomIndexError))
            {
                TempData["ShowRoomIndexError"] = roomIndexError.ToString();
                return RedirectToAction("Index");
            }

            DateTime checkInDate;
            DateTime checkOutDate;
            if (TempData.Peek("MyList") != null)
            {
                checkInDate = (DateTime)TempData.Peek("CheckInDate");
                checkOutDate = (DateTime)TempData.Peek("CheckOutDate");
            }
            else
            {
                checkInDate = DateTime.Parse(roomInformation.CheckInDate);
                checkOutDate = DateTime.Parse(roomInformation.CheckOutDate);
            }

            var resultRooms = RoomManager.GetRoomsWithCriteria(checkInDate, checkOutDate,
                roomInformation.Location, roomInformation.Category,
                roomInformation.HasWifi, roomInformation.HasParking,
                roomInformation.Type, roomInformation.Price,
                roomInformation.HasTV, roomInformation.HasHairDryer).Result.Value;

            if (resultRooms != null)
            {
                var resultWithInformations = new List<RoomWithInformationsModel>();
                foreach (var room in resultRooms)
                {
                    if (TempData.Peek("MyList") != null)
                    {
                        customerRoomsID = ((int[])TempData.Peek("MyList")).ToList();

                        if (!customerRoomsID.Contains(room.IdRoom))
                        {
                            resultWithInformations.Add(new RoomWithInformationsModel()
                            {
                                ResultRoom = room,
                                ResultHotel = HotelManager.GetHotelWithId(room.IdHotel).Result.Value,
                                ResultPictures = PictureManager.GetPicturesFromRoom(room.IdRoom).Result.Value
                            });
                        }
                    }
                    else
                    {
                        resultWithInformations.Add(new RoomWithInformationsModel()
                        {
                            ResultRoom = room,
                            ResultHotel = HotelManager.GetHotelWithId(room.IdHotel).Result.Value,
                            ResultPictures = PictureManager.GetPicturesFromRoom(room.IdRoom).Result.Value
                        });
                    }
                }


                if (TempData.Peek("MyList") == null)
                {
                    TempData["CheckInDate"] = roomInformation.CheckInDate;
                    TempData["CheckOutDate"] = roomInformation.CheckOutDate;
                }

                alreadySearched = roomInformation;

                if (sortMethod != 0)
                {
                    SortSearch(resultWithInformations);
                }

                return View(resultWithInformations);
            }

            TempData["ShowRoomIndexError"] = "Sorry, we don't seem to have any rooms that match your request. Please try again.";
            return RedirectToAction("Index");

        }

        private void SortSearch(List<RoomWithInformationsModel> resultToSort)
        {
            switch (sortMethod)
            {
                case 1:
                    SortByType(resultToSort);
                    break;
                case 2:
                    SortByPrice(resultToSort);
                    break;
                case 3:
                    SortByHotelName(resultToSort);
                    break;
            }
        }

        public IActionResult SortByType()
        {
            typeSortFlag = !typeSortFlag;
            sortMethod = 1;
            return RedirectToAction("ShowRooms", alreadySearched);
        }

        public IActionResult SortByPrice()
        {
            priceSortFlag = !priceSortFlag;
            sortMethod = 2;
            return RedirectToAction("ShowRooms", alreadySearched);
        }

        public IActionResult SortByHotelName()
        {
            hotelSortFlag = !hotelSortFlag;
            sortMethod = 3;
            return RedirectToAction("ShowRooms", alreadySearched);
        }

        private void SortByType(List<RoomWithInformationsModel> resultToSort)
        {
            if (typeSortFlag)
            {
                resultToSort.Sort((x, y) => x.ResultRoom.Type.CompareTo(y.ResultRoom.Type));
            }
            else
            {
                resultToSort.Sort((x, y) => y.ResultRoom.Type.CompareTo(x.ResultRoom.Type));
            }
        }

        private void SortByPrice(List<RoomWithInformationsModel> resultToSort)
        {
            if (priceSortFlag)
            {
                resultToSort.Sort((x, y) => x.ResultRoom.Price.CompareTo(y.ResultRoom.Price));
            }
            else
            {
                resultToSort.Sort((x, y) => y.ResultRoom.Price.CompareTo(x.ResultRoom.Price));
            }

        }

        private void SortByHotelName(List<RoomWithInformationsModel> resultToSort)
        {
            if (hotelSortFlag)
            {
                resultToSort.Sort((x, y) => x.ResultHotel.Name.CompareTo(y.ResultHotel.Name));
            }
            else
            {
                resultToSort.Sort((x, y) => y.ResultHotel.Name.CompareTo(x.ResultHotel.Name));
            }
        }

        private bool VerifyInformationIntegrity(SearchRoomInputModel roomInformation, StringBuilder roomIndexError)
        {
            var now = DateTime.Now;
            var checkInString = now.AddDays(1.0).ToShortDateString();
            var timeCheckIn = DateTime.Parse(checkInString);

            if (String.IsNullOrWhiteSpace(roomInformation.CheckInDate) | String.IsNullOrWhiteSpace(roomInformation.CheckOutDate))
            {
                roomInformation.CheckInDate = DateTime.Now.AddDays(1.0).ToShortDateString();
                roomInformation.CheckOutDate = DateTime.Now.AddDays(2.0).ToShortDateString();
            }


            if (!String.IsNullOrWhiteSpace(roomInformation.CheckInDate))
            {
                if (DateTime.Parse(roomInformation.CheckInDate).CompareTo(timeCheckIn) < 0)
                {
                    roomIndexError.Append("Your check-in date can't be before tomorrow.");
                    return false;
                }
            }

            if (!String.IsNullOrWhiteSpace(roomInformation.CheckOutDate))
            {
                if (DateTime.Parse(roomInformation.CheckOutDate).CompareTo(DateTime.Parse(roomInformation.CheckInDate)) <= 0)
                {
                    roomIndexError.Append("Your check-out date must be greater than your check-in date.");
                    return false;
                }
            }

            if (!String.IsNullOrWhiteSpace(roomInformation.CheckOutDate) & !String.IsNullOrWhiteSpace(roomInformation.CheckOutDate))
            {
                var differenceDate = DateTime.Parse(roomInformation.CheckOutDate).Subtract(DateTime.Parse(roomInformation.CheckInDate));
                if (differenceDate.Days > 28)
                {
                    roomIndexError.Append("Sorry, we are unable to manage reservation for more than 28 days.");
                    return false;
                }
            }


            if (roomInformation.Location != null)
            {
                if (roomInformation.Location.Count == 0)
                {
                    roomIndexError.Append("The location you are trying to access does not exist.");
                    return false;
                }

                foreach (var item in roomInformation.Location)
                {
                    if (!defaultInformation.PossibleLocations.Contains(item))
                    {
                        roomIndexError.Append("The location you are trying to access does not exist.");
                        return false;
                    }
                }
            }


            if (roomInformation.Category != null)
            {
                if (roomInformation.Category.Count == 0)
                {
                    roomIndexError.Append("The category you are trying to access does not exist.");
                    return false;
                }

                foreach (var item in roomInformation.Category)
                {
                    if (!defaultInformation.PossibleCategories.Contains(item))
                    {
                        roomIndexError.Append("The category you are trying to access does not exist.");
                        return false;
                    }
                }
            }

            if (roomInformation.Type != null)
            {
                if (roomInformation.Type.Count == 0)
                {
                    roomIndexError.Append("The type you are trying to access does not exist.");
                    return false;
                }
                foreach (var item in roomInformation.Type)
                {
                    if (!defaultInformation.PossibleTypes.Contains(item))
                    {
                        roomIndexError.Append("The type you are trying to access does not exist.");
                        return false;
                    }
                }
            }

            if (roomInformation.Price < 0.0M)
            {
                roomIndexError.Append("You cannot look for a room for less than 0 CHF.");
                return false;
            }

            if (roomInformation.Price > defaultInformation.MaxPrice)
            {
                roomIndexError.Append("We don't have any rooms at this price.");
                return false;
            }
            return true;
        }

        public IActionResult ShowBasket()
        {
            if (TempData.Peek("MyList") != null)
            {
                customerRoomsID = ((int[])TempData.Peek("MyList")).ToList();
            }
            else
            {
                customerRoomsID.Clear();
            }


            var roomsInBasket = new List<Room>();
            foreach (var roomID in customerRoomsID)
            {
                roomsInBasket.Add(RoomManager.GetRoomWithId(roomID, (DateTime)TempData.Peek("CheckInDate"), (DateTime)TempData.Peek("CheckOutDate")).Result.Value);
            }
            var clientInformation = new ClientInformationModel()
            {
                ReservedRoom = roomsInBasket
            };
            return View(clientInformation);
        }

        public IActionResult AddToBasket(int id)
        {
            var flag = false;

            if (TempData["MyList"] == null)
            {
                customerRoomsID.Clear();
            }

            foreach (var roomsID in customerRoomsID)
            {
                if (roomsID == id)
                {
                    flag = true;
                    break;
                }
            }

            if (!flag)
            {
                var room = RoomManager.GetRoomWithId(id, (DateTime)TempData.Peek("CheckInDate"), (DateTime)TempData.Peek("CheckOutDate")).Result.Value;
                customerRoomsID.Add(room.IdRoom);
                TempData["MyList"] = customerRoomsID;
            }


            return RedirectToAction("ShowRooms", alreadySearched);
        }

        public IActionResult DeleteFromBasket(int id)
        {
            customerRoomsID.Remove(id);
            TempData["MyList"] = customerRoomsID;
            return RedirectToAction("ShowBasket");
        }
    }
}
