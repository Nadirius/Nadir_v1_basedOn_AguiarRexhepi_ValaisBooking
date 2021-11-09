using DTO;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL
{
    public interface IHotelManager
    {
        Task<ActionResult<Hotel>> GetHotelWithId(int idHotel);


        Task<ActionResult<List<string>>> GetLocationsAvailable();

        Task<ActionResult<List<int>>> GetCategoriesAvailable();
    }
}