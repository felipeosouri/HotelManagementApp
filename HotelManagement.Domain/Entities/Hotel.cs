namespace HotelManagement.Domain.Entities
{
    public class Hotel
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Address { get; set; }
        public bool IsEnabled { get; set; }

        private List<Room> _rooms = new List<Room>();
        public IReadOnlyCollection<Room> Rooms => _rooms.AsReadOnly();

        public void AddRoom(Room room)
        {
            if (!IsEnabled)
                throw new InvalidOperationException("Cannot add rooms to a disabled hotel.");

            _rooms.Add(room);
        }

        public void Enable()
        {
            IsEnabled = true;
            foreach (var room in _rooms)
            {
                room.Enable();
            }
        }

        public void Disable()
        {
            IsEnabled = false;
            foreach (var room in _rooms)
            {
                room.Disable();
            }
        }
    }

}
