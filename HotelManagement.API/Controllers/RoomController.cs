using Microsoft.AspNetCore.Mvc;
using HotelManagement.Application.Services;
using HotelManagement.Application.DTOs.Room;
using HotelManagement.Domain.Entities;
using HotelManagement.Domain.ValueObjects;

namespace HotelManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomsController : ControllerBase
    {
        private readonly RoomService _roomService;
        private readonly HotelService _hotelService;

        public RoomsController(RoomService roomService, HotelService hotelService)
        {
            _roomService = roomService;
            _hotelService = hotelService;
        }

        [HttpGet("hotel/{hotelId}")]
        public async Task<ActionResult<IEnumerable<RoomDto>>> GetRoomsByHotel(int hotelId)
        {
            var rooms = await _roomService.GetRoomsByHotelIdAsync(hotelId);
            return Ok(rooms);
        }

        [HttpPost]
        public async Task<ActionResult> CreateRoom(CreateRoomDto roomDto)
        {
            var hotel = await _hotelService.GetHotelByIdAsync(roomDto.HotelId);
            if (hotel == null)
                return NotFound("Hotel not found");

            // Crear la instancia de Room usando el constructor
            var room = new Room(
                hotel: hotel,
                roomType: roomDto.RoomType,
                location: new RoomLocation(
                    floor: roomDto.Location.Floor,
                    wing: roomDto.Location.Wing,
                    roomNumber: roomDto.Location.RoomNumber
                )
            )
            {
                BasePrice = roomDto.BasePrice,
                Taxes = roomDto.Taxes
            };

            await _roomService.AddRoomAsync(room);

            return CreatedAtAction(nameof(GetRoomsByHotel), new { hotelId = room.HotelId }, room);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRoom(int id, UpdateRoomDto roomDto)
        {
            var room = await _roomService.GetByIdAsync(id);
            if (room == null)
                return NotFound();

            room.BasePrice = roomDto.BasePrice;
            room.Taxes = roomDto.Taxes;

            room.UpdateRoomType(roomDto.RoomType);
            room.UpdateLocation(new RoomLocation(
                roomDto.Location.Floor,
                roomDto.Location.Wing,
                roomDto.Location.RoomNumber
            ));

            if (roomDto.IsEnabled)
            {
                room.Enable();
            }
            else
            {
                room.Disable();
            }

            await _roomService.UpdateRoomAsync(room);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DisableRoom(int id)
        {
            await _roomService.DisableRoomAsync(id);
            return NoContent();
        }
    }

}
