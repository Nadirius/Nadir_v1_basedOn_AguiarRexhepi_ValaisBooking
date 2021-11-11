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


        public IActionResult Index(int id)
        {
            var hotelToShow = HotelManager.GetHotelWithIdAsync(id);
            return View(hotelToShow);
        }
    }
}
