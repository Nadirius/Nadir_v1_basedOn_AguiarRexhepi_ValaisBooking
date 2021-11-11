using DTO;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL
{

    public interface IRoomManager
    {
        Task<decimal> GetMaximumPriceAsync();
        Task<ICollection<Room>> GetRoomsAsync();
        Task<ICollection<Room>> GetRoomsWithCriteriaAsync(DateTime checkInDate, DateTime checkOutDate, ICollection<string> location = null, ICollection<int> category = null, bool hasWifi = true, bool hasParking = true, ICollection<int> type = null, decimal price = 0.0M, bool hasTV = true, bool hasHairDryer = true);
        Task<Room> GetRoomWithIdAsync(int RoomId, DateTime checkInDate, DateTime checkOutDate);
        Task<ICollection<int>> GetTypesAvailableAsync();
    }
}