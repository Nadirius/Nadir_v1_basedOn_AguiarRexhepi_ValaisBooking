
using DTO;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace BLL
{
    public interface IReservationManager
    {
        Task<ActionResult<Reservation>> GetReservationsWithIdentification(string identification);

        Task<ActionResult<Reservation>> InsertReservation(string firstName, string lastName, DateTime checkInDate, DateTime checkOutDate, decimal amount, int idRoom);

        Task<ActionResult<int>> DeleteReservation(string reservationToDelete);
    }
}