using Alten.HotelChallenge.Application.Repositories;

namespace Alten.HotelChallenge.Application.UseCases.GetRoomAvailability
{
    public class GetRoomAvailability : IGetRoomAvailability
    {
        private readonly IRoomRepository _roomRepository;
        public GetRoomAvailability(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }


        public async Task<GetRoomAvailabilityOutput> Handle(GetRoomAvailabilityInput request, CancellationToken cancellationToken)
        {
            return await _roomRepository.GetAvailabilityForPeriodAsync(request, cancellationToken);
        }
    }
}
