using HotelManagement.Domain.Entities;
using HotelManagement.Domain.Interfaces;

namespace HotelManagement.Application.Services
{
    public class RoomService
    {
        private readonly IRoomRepository _roomRepository;

        public RoomService(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }

        public async Task<Room> GetByIdAsync(int id)
        {
            return await _roomRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Room>> GetRoomsByHotelIdAsync(int hotelId)
        {
            return await _roomRepository.GetRoomsByHotelIdAsync(hotelId);
        }

        public async Task AddRoomAsync(Room room)
        {
            await _roomRepository.AddAsync(room);
        }

        public async Task UpdateRoomAsync(Room room)
        {
            await _roomRepository.UpdateAsync(room);
        }

        public async Task DisableRoomAsync(int id)
        {
            var room = await _roomRepository.GetByIdAsync(id);
            if (room != null)
            {
                room.Disable();
                await _roomRepository.UpdateAsync(room);
            }
        }
    }

}
