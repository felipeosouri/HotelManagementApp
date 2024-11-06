namespace HotelManagement.Application.DTOs.Room
{
    public class UpdateRoomDto
    {
        public decimal BasePrice { get; set; }
        public decimal Taxes { get; set; }
        public required string RoomType { get; set; }
        public required RoomLocationDto Location { get; set; }
        public bool IsEnabled { get; set; }
    }
}
