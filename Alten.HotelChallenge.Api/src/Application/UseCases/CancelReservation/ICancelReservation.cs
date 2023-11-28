using MediatR;

namespace Alten.HotelChallenge.Application.UseCases.CancelReservation
{
    internal interface ICancelReservation : IRequestHandler<CancelReservationInput, bool>
    {
    }
}
