namespace HotelManagement.Application.DTOs.Hotel
{
    public class UpdateHotelDto
    {
        public required string Name { get; set; }
        public required string Address { get; set; }
        public bool IsEnabled { get; set; }
    }
}
