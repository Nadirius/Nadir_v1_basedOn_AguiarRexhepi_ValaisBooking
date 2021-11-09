using DTO;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL
{

    public interface IRoomManager
    {

        Task<ActionResult<Room>> GetRoomWithId(int idRoom, DateTime checkInDate, DateTime checkOutDate);

        Task<ActionResult<List<Room>>> GetRoomsWithCriteria(DateTime checkInDate, 
            DateTime checkOutDate, 
            List<string> location = null, 
            List<int> category = null, 
            bool hasWifi = true,
            bool hasParking = true, 
            List<int> type = null, 
            decimal price = 0.0M, 
            bool hasTV = true, 
            bool hasHairDryer = true);

        Task<ActionResult<List<int>>> GetTypesAvailable();

        Task<ActionResult<decimal>> GetMaximumPrice();

    }
}