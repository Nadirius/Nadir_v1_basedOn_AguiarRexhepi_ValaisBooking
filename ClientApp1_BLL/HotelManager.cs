using DTO;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WAPIL;

namespace BLL
{

    public class HotelManager : IHotelManager
    {
        private readonly IBookingWebApiInvoker _helloWorld;

        public HotelManager(IBookingWebApiInvoker apiInvoker)
        {
            this._helloWorld = apiInvoker;
        }

        public async Task<IEnumerable<Hotel>> GetAsync()
        {
            return await _helloWorld.InvokeGet<IEnumerable<Hotel>>("hotels");
        }

        public async Task<Hotel> GetByIdAsync(int id)
        {
            return await _helloWorld.InvokeGet<Hotel>($"hotels/{id}");
        }

                public async Task<IEnumerable<Room>> GetHotelRoomsAsync(int roomId)
        {
            return await _helloWorld.InvokeGet<IEnumerable<Room>>($"hotels/{roomId}/rooms");
        }

        public async Task<ActionResult<Hotel>> GetHotelWithId(int idHotel)
        {
            throw new System.NotImplementedException();
        }

        public async Task<ActionResult<List<string>>> GetLocationsAvailable()
        {
            throw new System.NotImplementedException();
        }



        public async Task<ActionResult<List<int>>> GetCategoriesAvailable()
        {
            throw new System.NotImplementedException();
        }

    }
}
