using System;
namespace DTO
{
    public class Reservation
    {
        public int IdReservation { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime CheckIn { get; set; }

        public DateTime CheckOut { get; set; }

        public decimal Amount { get; set; }

        public int IdRoom { get; set; }

    }
}
