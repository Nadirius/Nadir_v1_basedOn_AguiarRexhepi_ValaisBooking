
using DTO;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL
{
	//
	// Summary:
	//     Interface that contains the methods' definition to manage informations from the database's ReservationDB
	//
	public interface IReservationManager
	{
		//
		// Summary:
		//   Gets a Reservation entry in our database given his identification.  
		//
		// Parameters:
		//   identification:
		//     The Reservation's identification we are looking for.
		//
		// Returns:
		//     A Reservation in our database.
		Task<ActionResult<Reservation>> GetReservationsWithIdentification(string identification);

		//
		// Summary:
		//   Inserts a new client reservation.  
		//
		// Parameters:
		//   firstName:
		//     The client's first name.
		//
		//   lastName:
		//     The client's last name.
		//
		//   checkInDate;
		//     The check in date of the client.
		//
		//   checkOuDate;
		//     The check out date of the client.
		//
		//   amount;
		//     The amount payed by the client.
		//
		//   idRoom;
		//     The room reserved by the client.
		//
		// Returns:
		//     A Reservation object which contains the inserted client's information.
		Task<ActionResult<Reservation>> InsertReservation(string firstName, string lastName, DateTime checkInDate, DateTime checkOutDate, decimal amount, int idRoom);

		//
		// Summary:
		//   Delets a client reservation.  
		//
		// Parameters:
		//   reservationToDelete:
		//     The concatenation of the reservation ID, followed by the client's first and last name.
		//
		// Returns:
		//     An int that informs you if the delete was successful.
		Task<ActionResult<int>> DeleteReservation(string reservationToDelete);
	}
}