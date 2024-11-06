namespace HotelManagement.Domain.Entities
{
    public class Passenger
    {
        public int Id { get; set; }
        public int ReservationId { get; set; }
        public Reservation Reservation { get; set; } // Sin `required`

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string DocumentType { get; set; }
        public string DocumentNumber { get; set; }
        public string Email { get; set; }
        public string ContactPhone { get; set; }

        // Constructor que inicializa las propiedades requeridas
        public Passenger(
            string firstName,
            string lastName,
            DateTime dateOfBirth,
            string gender,
            string documentType,
            string documentNumber,
            string email,
            string contactPhone)
        {
            FirstName = firstName ?? throw new ArgumentNullException(nameof(firstName));
            LastName = lastName ?? throw new ArgumentNullException(nameof(lastName));
            DateOfBirth = dateOfBirth;
            Gender = gender ?? throw new ArgumentNullException(nameof(gender));
            DocumentType = documentType ?? throw new ArgumentNullException(nameof(documentType));
            DocumentNumber = documentNumber ?? throw new ArgumentNullException(nameof(documentNumber));
            Email = email ?? throw new ArgumentNullException(nameof(email));
            ContactPhone = contactPhone ?? throw new ArgumentNullException(nameof(contactPhone));
        }
    }
}
