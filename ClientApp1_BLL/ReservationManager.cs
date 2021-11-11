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

        public async Task<int> DeleteReservationAsync(string reservationToDelete)
        {
            throw new NotImplementedException();
        }

        public async Task<Reservation> GetReservationsWithIdentificationAsync(string identification)
        {
            throw new NotImplementedException();
        }

        public async Task<Reservation> InsertReservationAsync(string firstName, string lastName, DateTime checkInDate, DateTime checkOutDate, decimal amount, int RoomId)
        {
            throw new NotImplementedException();
        }
    }
}
