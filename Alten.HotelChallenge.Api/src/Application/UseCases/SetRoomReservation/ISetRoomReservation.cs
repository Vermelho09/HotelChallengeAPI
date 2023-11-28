using MediatR;

namespace Alten.HotelChallenge.Application.UseCases.SetRoomReservation
{
    internal interface ISetRoomReservation : IRequestHandler<SetRoomReservationInput, bool>
    {
    }
}
