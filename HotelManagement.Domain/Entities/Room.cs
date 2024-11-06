using HotelManagement.Domain.ValueObjects;

namespace HotelManagement.Domain.Entities
{
    public class Room
    {
        public int Id { get; set; }
        public int HotelId { get; set; }
        public Hotel Hotel { get; private set; }

        public decimal BasePrice { get; set; }
        public decimal Taxes { get; set; }
        public string RoomType { get; private set; }
        public RoomLocation Location { get; private set; }
        public bool IsEnabled { get; private set; }
        public Room(Hotel hotel, string roomType, RoomLocation location)
        {
            Hotel = hotel ?? throw new ArgumentNullException(nameof(hotel));
            HotelId = hotel.Id;
            RoomType = roomType ?? throw new ArgumentNullException(nameof(roomType));
            Location = location ?? throw new ArgumentNullException(nameof(location));
            IsEnabled = true;
        }
        
        public void Enable() => IsEnabled = true;
        public void Disable() => IsEnabled = false;

        public void UpdateRoomType(string roomType)
        {
            RoomType = roomType ?? throw new ArgumentNullException(nameof(roomType));
        }

        public void UpdateLocation(RoomLocation location)
        {
            Location = location ?? throw new ArgumentNullException(nameof(location));
        }
    }
}

