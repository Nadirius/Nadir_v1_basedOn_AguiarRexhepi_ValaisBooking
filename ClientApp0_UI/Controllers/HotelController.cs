using BLL;
using Microsoft.AspNetCore.Mvc;

namespace UI
{
	//
	// Summary:
	//     Controller for our Hotel.
	//
	public class HotelController : Controller
	{
		// IHotelManager of our controller.
		private IHotelManager HotelManager { get; }

		//
		// Summary:
		//     Constructor of our HotelController object.
		//
		// Parameters:
		//   hotelManager:
		//     The IHotelManager object.
		//
		public HotelController(IHotelManager hotelManager)
		{
			HotelManager = hotelManager;
		}

		//
		// Summary:
		//   Gets the Index view of our Hotel.  
		//
		// Parameters:
		//   id:
		//     The Hotel's id.
		//
		// Returns:
		//     An IActionResult that is the Index view of our Hotel.
		public IActionResult Index(int id)
		{
			var hotelToShow = HotelManager.GetHotelWithId(id);
			return View(hotelToShow);
		}
	}
}
