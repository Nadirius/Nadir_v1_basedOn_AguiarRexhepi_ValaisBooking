using DTO;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL
{
	//
	// Summary:
	//     Interface that contains the methods' definition to manage informations from the database's ImageDB
	//
	public interface IPictureManager
	{
		//
		// Summary:
		//   Gets all Picture entries in our database given the id of a room.  
		//
		// Parameters:
		//   idRoom:
		//     The Picture's room id we are looking for.
		//
		// Returns:
		//     A List of all Pictures in our database.
		Task<ActionResult<List<Picture>>> GetPicturesFromRoom(int idRoom);
	}
}