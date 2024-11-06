namespace HotelManagement.Domain.ValueObjects
{
    public class RoomLocation
    {
        public string Floor { get; }
        public string Wing { get; }
        public string RoomNumber { get; }

        public RoomLocation(string floor, string wing, string roomNumber)
        {
            Floor = floor;
            Wing = wing;
            RoomNumber = roomNumber;
        }

        public override bool Equals(object obj)
        {
            if (obj is not RoomLocation other) return false;
            return Floor == other.Floor && Wing == other.Wing && RoomNumber == other.RoomNumber;
        }

        public override int GetHashCode() => HashCode.Combine(Floor, Wing, RoomNumber);
    }

}
