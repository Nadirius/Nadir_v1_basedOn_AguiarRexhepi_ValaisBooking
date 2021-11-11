
using DTO;
using Microsoft.AspNetCore.Mvc;
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

        //Get Hotels - ok
        public async Task<ICollection<Hotel>> GetHotelsAsync()
        {
            return await _helloWorld.InvokeGet<ICollection<Hotel>>("hotels");
        }

        //Get Hotel by id - ok
        public async Task<Hotel> GetHotelWithIdAsync(int id)
        {
            return await _helloWorld.InvokeGet<Hotel>($"hotels/{id}");
        }

        //Get Hotel Rooms - ok
        public async Task<ICollection<Room>> GetHotelRoomsAsync(int roomId)
        {
            return await _helloWorld.InvokeGet<ICollection<Room>>($"hotels/{roomId}/rooms");
        }

        public async Task<ICollection<string>> GetLocationsAvailableAsync()
        {
            return await _helloWorld.InvokeGet<ICollection<string>>($"hotels/locations");
        }

        public async Task<ICollection<int>> GetCategoriesAvailableAsync()
        {
            return await _helloWorld.InvokeGet<ICollection<int>>($"hotels/Categories");
        }

    }
}
