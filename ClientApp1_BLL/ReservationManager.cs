using DTO;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using WAPIL;

namespace BLL
{
    //
    // Summary:
    //     Class that contains the methods to manage informations from ReservationDB
    //
    public class ReservationManager : IReservationManager
    {
        private readonly IBookingWebApiInvoker _helloWorld;

        public ReservationManager(IBookingWebApiInvoker apiInvoker)
        {
            this._helloWorld = apiInvoker;
        }

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
