namespace HotelManagement.Application.DTOs.Hotel
{
    public class HotelDto
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Address { get; set; }
        public bool IsEnabled { get; set; }
    }
}
