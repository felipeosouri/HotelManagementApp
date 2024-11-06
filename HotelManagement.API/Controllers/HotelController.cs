using Microsoft.AspNetCore.Mvc;
using HotelManagement.Application.Services;
using HotelManagement.Application.DTOs.Hotel;
using HotelManagement.Domain.Entities;

namespace HotelManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelsController : ControllerBase
    {
        private readonly HotelService _hotelService;

        public HotelsController(HotelService hotelService)
        {
            _hotelService = hotelService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<HotelDto>>> GetAllHotels()
        {
            var hotels = await _hotelService.GetAllHotelsAsync();
            return Ok(hotels);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<HotelDto>> GetHotelById(int id)
        {
            var hotel = await _hotelService.GetHotelByIdAsync(id);
            if (hotel == null)
                return NotFound();

            return Ok(hotel);
        }

        [HttpPost]
        public async Task<ActionResult> CreateHotel(CreateHotelDto hotelDto)
        {
            var hotel = new Hotel { Name = hotelDto.Name, Address = hotelDto.Address, IsEnabled = true };
            await _hotelService.AddHotelAsync(hotel);
            return CreatedAtAction(nameof(GetHotelById), new { id = hotel.Id }, hotel);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateHotel(int id, UpdateHotelDto hotelDto)
        {
            var hotel = await _hotelService.GetHotelByIdAsync(id);
            if (hotel == null)
                return NotFound();

            hotel.Name = hotelDto.Name;
            hotel.Address = hotelDto.Address;
            hotel.IsEnabled = hotelDto.IsEnabled;
            await _hotelService.UpdateHotelAsync(hotel);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHotel(int id)
        {
            await _hotelService.DisableHotelAsync(id);
            return NoContent();
        }
    }

}
