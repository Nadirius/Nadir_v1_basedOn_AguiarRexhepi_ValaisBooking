using DTO;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL
{
	//
	// Summary:
	//     Interface that contains the methods' definition to manage informations from the database's RoomDB
	//
	public interface IRoomManager
	{
		//
		// Summary:
		//   Gets a Room entry in our database given his id.  
		//
		// Parameters:
		//   idRoom:
		//     The Room's id we are looking for.
		//
		//   checkInDate:
		//     The Room's checkInDate criteria.
		//
		//   checkOutDate:
		//     The Room's checkOutDate criteria.
		//
		// Returns:
		//     A Room in our database.
		Task<ActionResult<Room>> GetRoomWithId(int idRoom, DateTime checkInDate, DateTime checkOutDate);

		//
		// Summary:
		//   Gets all Rooms entries matching given Hotel and Room criteria.  
		//
		// Parameters:
		//   checkInDate:
		//     The Room's checkInDate criteria.
		//
		//   checkOutDate:
		//     The Room's checkOutDate criteria.
		//
		//   location:
		//     The Hotel's location criteria.
		//
		//   category:
		//     The Hotel's category criteria.
		//
		//   hasWifi:
		//     The Hotel's wifi criteria.
		//
		//   hasParking:
		//     The Hotel's parking criteria.
		//
		//   type:
		//     The Room's type criteria.
		//
		//   price:
		//     The Room's price criteria.
		//
		//   hasTV:
		//     The Room's tv criteria.
		//
		//   hasHairDryer:
		//     The Room's hair dryer criteria.
		//
		// Returns:
		//     A List of all Rooms available in our database.
		Task<ActionResult<List<Room>>> GetRoomsWithCriteria(DateTime checkInDate, DateTime checkOutDate, List<string> location = null, List<int> category = null, bool hasWifi = true,
			bool hasParking = true, List<int> type = null, decimal price = 0.0M, bool hasTV = true, bool hasHairDryer = true);

		//
		// Summary:
		//   Gets all Room types available. 
		//
		// Returns:
		//     A List of Room types available. 
		Task<ActionResult<List<int>>> GetTypesAvailable();

		//
		// Summary:
		//   Gets Maximum price possible. 
		//
		// Returns:
		//     The maximum price possible. 
		Task<ActionResult<decimal>> GetMaximumPrice();

	}
}