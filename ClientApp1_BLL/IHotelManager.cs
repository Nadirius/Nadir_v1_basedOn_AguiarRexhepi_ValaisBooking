using DTO;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL
{
    public interface IHotelManager
    {
        Task<ICollection<int>> GetCategoriesAvailableAsync();
        Task<ICollection<Room>> GetHotelRoomsAsync(int roomId);
        Task<ICollection<Hotel>> GetHotelsAsync();
        Task<Hotel> GetHotelWithIdAsync(int id);
        Task<ICollection<string>> GetLocationsAvailableAsync();
    }
}