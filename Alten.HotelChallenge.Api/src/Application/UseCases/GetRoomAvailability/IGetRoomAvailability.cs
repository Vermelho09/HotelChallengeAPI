using MediatR;

namespace Alten.HotelChallenge.Application.UseCases.GetRoomAvailability
{
    internal interface IGetRoomAvailability : IRequestHandler<GetRoomAvailabilityInput, GetRoomAvailabilityOutput>
    {
    }
}
