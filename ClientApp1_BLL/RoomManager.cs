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

        public Task<ActionResult<decimal>> GetMaximumPrice()
        {
            throw new NotImplementedException();
        }

        public Task<ActionResult<List<Room>>> GetRoomsWithCriteria(DateTime checkInDate, DateTime checkOutDate, List<string> location = null, List<int> category = null, bool hasWifi = true, bool hasParking = true, List<int> type = null, decimal price = 0.0M, bool hasTV = true, bool hasHairDryer = true)
        {
            throw new NotImplementedException();
        }

        public Task<ActionResult<Room>> GetRoomWithId(int idRoom, DateTime checkInDate, DateTime checkOutDate)
        {
            throw new NotImplementedException();
        }

        public Task<ActionResult<List<int>>> GetTypesAvailable()
        {
            throw new NotImplementedException();
        }
    }

}