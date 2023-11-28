using MediatR;

namespace Alten.HotelChallenge.Application.UseCases.CancelReservation
{
    public class CancelReservationInput : IRequest<bool>
    {
        public long ReservationId { get; set; }
    }
}
