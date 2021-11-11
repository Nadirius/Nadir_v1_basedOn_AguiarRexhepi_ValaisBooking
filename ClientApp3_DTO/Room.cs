namespace DTO
{
    public class Room
    {
        public int RoomId { get; set; }

        public int Number { get; set; }

        public string Description { get; set; }

        public int Type { get; set; }

        public decimal Price { get; set; }

        public bool HasTV { get; set; }

        public bool HasHairDryer { get; set; }

        public int HotelId { get; set; }

        public override string ToString()
        {
            return $"{RoomId} {Number} {Description} {Type} " +
                $"{Price} {HasTV} {HasHairDryer} {HotelId}";
        }


    }
}
