namespace DTO
{
    public class Picture
    {
        public int PictureId { get; set; }

        public string Url { get; set; }

        public int RoomId { get; set; }

        public override string ToString()
        {
            return $"{PictureId} {Url} {RoomId}";
        }
    }
}
