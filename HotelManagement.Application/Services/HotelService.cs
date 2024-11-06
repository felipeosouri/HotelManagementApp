using HotelManagement.Domain.Entities;
using HotelManagement.Domain.Interfaces;

namespace HotelManagement.Application.Services
{
    public class HotelService
    {
        private readonly IHotelRepository _hotelRepository;

        public HotelService(IHotelRepository hotelRepository)
        {
            _hotelRepository = hotelRepository;
        }

        public async Task<IEnumerable<Hotel>> GetAllHotelsAsync()
        {
            return await _hotelRepository.GetAllAsync();
        }

        public async Task<Hotel> GetHotelByIdAsync(int id)
        {
            return await _hotelRepository.GetByIdAsync(id);
        }

        public async Task AddHotelAsync(Hotel hotel)
        {
            await _hotelRepository.AddAsync(hotel);
        }

        public async Task UpdateHotelAsync(Hotel hotel)
        {
            await _hotelRepository.UpdateAsync(hotel);
        }

        public async Task DisableHotelAsync(int id)
        {
            var hotel = await _hotelRepository.GetByIdAsync(id);
            if (hotel != null)
            {
                hotel.Disable();
                await _hotelRepository.UpdateAsync(hotel);
            }
        }
    }

}
