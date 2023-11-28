using Alten.HotelChallenge.Application.UseCases.SetRoomReservation;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Alten.HotelChallenge.Application.UseCases.ModifyReservation
{
    public class ModifyReservationInput : SetRoomReservationInput, IRequest<bool>
    {
        [Required]
        public long ReservationId { get; set; }
    }
}
