using System.Collections.Generic;

namespace UI
{
    public class SearchRoomInputModel
    {
        public string CheckInDate { get; set; }

        public string CheckOutDate { get; set; }

        public List<string> Location { get; set; }

        public List<int> Category { get; set; }

        public bool HasWifi { get; set; }

        public bool HasParking { get; set; }

        public List<int> Type { get; set; }

        public decimal Price { get; set; }

        public bool HasTV { get; set; }

        public bool HasHairDryer { get; set; }

        public List<string> PossibleLocations { get; set; }

        public List<int> PossibleCategories { get; set; }

        public List<int> PossibleTypes { get; set; }

        public decimal MaxPrice { get; set; }

    }
}
