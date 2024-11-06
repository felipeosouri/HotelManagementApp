namespace HotelManagement.Application.DTOs.Reservation
{
    public class ReservationDto
    {
        public int Id { get; set; }
        public int RoomId { get; set; }
        public DateTime ReservationDate { get; set; }
        public required List<PassengerDto> Passengers { get; set; }
        public required ContactDto EmergencyContact { get; set; }
    }
}
