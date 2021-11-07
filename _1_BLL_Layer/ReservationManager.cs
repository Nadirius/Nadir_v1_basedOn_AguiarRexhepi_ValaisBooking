using DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
	//
	// Summary:
	//     Class that contains the methods to manage informations from ReservationDB
	//
	public class ReservationManager : BLLManager, IReservationManager
	{

		public ReservationManager(IConfiguration configuration, HttpClient httpClient) : base(configuration, httpClient) {}

        public async Task<ActionResult<int>> DeleteReservation(string reservationToDelete)
        {
            throw new NotImplementedException();
        }

        public async Task<ActionResult<Reservation>> GetReservationsWithIdentification(string identification)
        {
            throw new NotImplementedException();
        }

        public async Task<ActionResult<Reservation>> InsertReservation(string firstName, string lastName, DateTime checkInDate, DateTime checkOutDate, decimal amount, int idRoom)
        {
            throw new NotImplementedException();
        }
    }
}
