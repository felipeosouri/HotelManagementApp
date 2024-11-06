using HotelManagement.Domain.ValueObjects;

namespace HotelManagement.Domain.Entities
{
    public class Reservation
    {
        public int Id { get; set; }
        public int RoomId { get; set; }

        public Room Room { get; private set; }

        public DateTime ReservationDate { get; set; }

        private List<Passenger> _passengers = new List<Passenger>();
        public IReadOnlyCollection<Passenger> Passengers => _passengers.AsReadOnly();

        public Contact EmergencyContact { get; private set; }
        
        public Reservation(Room room, DateTime reservationDate)
        {
            Room = room ?? throw new ArgumentNullException(nameof(room));
            RoomId = room.Id;
            ReservationDate = reservationDate;
        }
        public void AddPassenger(Passenger passenger)
        {
            if (passenger == null) throw new ArgumentNullException(nameof(passenger));
            _passengers.Add(passenger);
        }
        public void SetEmergencyContact(Contact contact)
        {
            EmergencyContact = contact ?? throw new ArgumentNullException(nameof(contact));
        }
    }


}
