using DTO;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace BLL
{
	//
	// Summary:
	//     Interface that contains the methods' definition to manage informations from the database's HotelDB
	//
	public interface IHotelManager
	{
		//
		// Summary:
		//   Gets an Hotel entry in our database given his id.  
		//
		// Parameters:
		//   idHotel:
		//     The Hotel's id we are looking for.
		//
		// Returns:
		//     An Hotel in our database.
		Task<ActionResult<Hotel>> GetHotelWithId(int idHotel);

		//
		// Summary:
		//   Gets all Hotel locations available. 
		//
		// Returns:
		//     A List of Hotels locations available. 
		Task<ActionResult<List<string>>> GetLocationsAvailable();

		//
		// Summary:
		//   Gets all Hotel categories available. 
		//
		// Returns:
		//     A List of Hotels categories available. 
		Task<ActionResult<List<int>>> GetCategoriesAvailable();
	}
}