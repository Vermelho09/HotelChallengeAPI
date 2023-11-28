using Alten.HotelChallenge.Application.UseCases.GetRoomAvailability;

namespace Alten.HotelChallenge.Application.Repositories
{
    public interface IRoomRepository
    {
        Task<GetRoomAvailabilityOutput> GetAvailabilityForPeriodAsync(GetRoomAvailabilityInput getRoomAvailabilityInput, CancellationToken cancellationToken);
    }
}
