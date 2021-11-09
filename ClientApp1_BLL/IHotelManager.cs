using DTO;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace BLL
{
	public interface IHotelManager
	{
		Task<ActionResult<Hotel>> GetHotelWithId(int idHotel);


		Task<ActionResult<List<string>>> GetLocationsAvailable();

		Task<ActionResult<List<int>>> GetCategoriesAvailable();
	}
}