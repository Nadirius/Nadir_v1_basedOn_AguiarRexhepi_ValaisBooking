using DTO;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WAPIL;

namespace BLL
{
    public class RoomManager : IRoomManager
    {
        private readonly IBookingWebApiInvoker _helloWorld;

        public RoomManager(IBookingWebApiInvoker apiInvoker)
        {
            this._helloWorld = apiInvoker;
        }

        public async Task<ICollection<Room>> GetRoomsAsync()
        {
            return await _helloWorld.InvokeGet<ICollection<Room>>("rooms");
        }

        public Task<Room> GetRoomWithIdAsync(int RoomId,
            DateTime checkInDate,
            DateTime checkOutDate)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<Room>> GetRoomsWithCriteriaAsync(DateTime checkInDate,
            DateTime checkOutDate,
            ICollection<string> location = null,
            ICollection<int> category = null,
            bool hasWifi = true,
            bool hasParking = true,
            ICollection<int> type = null,
            decimal price = 0.0M,
            bool hasTV = true,
            bool hasHairDryer = true)
        {
            throw new NotImplementedException();
        }



        public Task<ICollection<int>> GetTypesAvailableAsync()
        {
            throw new NotImplementedException();
        }

        public Task<decimal> GetMaximumPriceAsync()
        {
            throw new NotImplementedException();
        }

    }

}