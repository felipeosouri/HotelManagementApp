namespace HotelManagement.Application.DTOs.Reservation
{
    public class PassengerDto
    {
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public required string Gender { get; set; }
        public required string DocumentType { get; set; }
        public required string DocumentNumber { get; set; }
        public required string Email { get; set; }
        public required string ContactPhone { get; set; }
    }
}
