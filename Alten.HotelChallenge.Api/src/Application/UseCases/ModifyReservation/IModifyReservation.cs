using MediatR;

namespace Alten.HotelChallenge.Application.UseCases.ModifyReservation
{
    internal interface IModifyReservation : IRequestHandler<ModifyReservationInput, bool>
    {
    }
}
