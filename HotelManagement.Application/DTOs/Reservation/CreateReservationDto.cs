namespace HotelManagement.Application.DTOs.Reservation
{
    public class CreateReservationDto
    {
        public int RoomId { get; set; }
        public required List<PassengerDto> Passengers { get; set; }
        public required ContactDto EmergencyContact { get; set; }
    }
}
