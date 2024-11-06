namespace HotelManagement.Application.DTOs.Room
{
    public class RoomDto
    {
        public int Id { get; set; }
        public int HotelId { get; set; }
        public decimal BasePrice { get; set; }
        public decimal Taxes { get; set; }
        public required string RoomType { get; set; }
        public required RoomLocationDto Location { get; set; }
        public bool IsEnabled { get; set; }
    }
}
