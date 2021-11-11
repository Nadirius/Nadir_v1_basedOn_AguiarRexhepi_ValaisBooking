using System.Collections.Generic;

namespace UI
{
    public class SearchRoomInputModel
    {
        public string CheckInDate { get; set; }

        public string CheckOutDate { get; set; }

        public ICollection<string> Location { get; set; }

        public ICollection<int> Category { get; set; }

        public bool HasWifi { get; set; }

        public bool HasParking { get; set; }

        public ICollection<int> Type { get; set; }

        public decimal Price { get; set; }

        public bool HasTV { get; set; }

        public bool HasHairDryer { get; set; }

        public ICollection<string> PossibleLocations { get; set; }

        public ICollection<int> PossibleCategories { get; set; }

        public ICollection<int> PossibleTypes { get; set; }

        public decimal MaxPrice { get; set; }

    }
}
