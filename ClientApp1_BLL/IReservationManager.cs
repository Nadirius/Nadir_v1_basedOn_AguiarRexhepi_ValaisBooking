
using DTO;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace BLL
{
    public interface IReservationManager
    {
        Task<Reservation> GetReservationsWithIdentificationAsync(string identification);

        Task<Reservation> InsertReservationAsync(string firstName, string lastName, DateTime checkInDate, DateTime checkOutDate, decimal amount, int RoomId);

        Task<int> DeleteReservationAsync(string reservationToDelete);
    }
}