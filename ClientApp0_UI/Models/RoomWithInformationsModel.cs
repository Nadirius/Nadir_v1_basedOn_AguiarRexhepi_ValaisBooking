using DTO;
using System.Collections.Generic;

namespace UI
{
    public class RoomWithInformationsModel
    {
        public Room ResultRoom { get; set; }

        public Hotel ResultHotel { get; set; }

        public ICollection<Picture> ResultPictures { get; set; }

    }
}
