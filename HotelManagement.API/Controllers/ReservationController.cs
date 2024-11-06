using Microsoft.AspNetCore.Mvc;
using HotelManagement.Application.Services;
using HotelManagement.Application.DTOs.Reservation;
using HotelManagement.Domain.Entities;
using HotelManagement.Domain.ValueObjects;

namespace HotelManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationsController : ControllerBase
    {
        private readonly ReservationService _reservationService;
        private readonly RoomService _roomService;

        public ReservationsController(ReservationService reservationService, RoomService roomService)
        {
            _reservationService = reservationService;
            _roomService = roomService;
        }

        [HttpGet("hotel/{hotelId}")]
        public async Task<ActionResult<IEnumerable<ReservationDto>>> GetReservationsByHotel(int hotelId)
        {
            var reservations = await _reservationService.GetReservationsByHotelIdAsync(hotelId);
            return Ok(reservations);
        }

        [HttpPost]
        public async Task<ActionResult> CreateReservation(CreateReservationDto reservationDto)
        {
            var room = await _roomService.GetByIdAsync(reservationDto.RoomId);
            if (room == null)
                return NotFound("Room not found");

            var reservation = new Reservation(room, DateTime.Now);

            reservation.SetEmergencyContact(new Contact(
                reservationDto.EmergencyContact.FullName,
                reservationDto.EmergencyContact.ContactPhone
            ));

            foreach (var passengerDto in reservationDto.Passengers)
            {
                var passenger = new Passenger(
                    firstName: passengerDto.FirstName,
                    lastName: passengerDto.LastName,
                    dateOfBirth: passengerDto.DateOfBirth,
                    gender: passengerDto.Gender,
                    documentType: passengerDto.DocumentType,
                    documentNumber: passengerDto.DocumentNumber,
                    email: passengerDto.Email,
                    contactPhone: passengerDto.ContactPhone
                );

                reservation.AddPassenger(passenger);
            }

            await _reservationService.AddReservationAsync(reservation);

            return CreatedAtAction(
                nameof(GetReservationsByHotel),
                new { hotelId = reservation.Room.HotelId },
                reservation
            );
        }

    }

}
