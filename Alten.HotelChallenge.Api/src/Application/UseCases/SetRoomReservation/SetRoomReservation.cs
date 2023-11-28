using Alten.HotelChallenge.Application.Repositories;
using Alten.HotelChallenge.Application.UseCases.GetRoomAvailability;

namespace Alten.HotelChallenge.Application.UseCases.SetRoomReservation
{
    public class SetRoomReservation : ISetRoomReservation
    {
        private readonly IReservationRepository _reservationRepository;
        private readonly IRoomRepository _roomRepository;
        public SetRoomReservation(IReservationRepository reservationRepository, IRoomRepository roomRepository)
        {
            _reservationRepository = reservationRepository;
            _roomRepository = roomRepository;
        }

        public async Task<bool> Handle(SetRoomReservationInput request, CancellationToken cancellationToken)
        {
            var availability = await _roomRepository.GetAvailabilityForPeriodAsync(new GetRoomAvailabilityInput { RoomId = request.RoomId, StartDate = request.StartDate, EndDate = request.EndDate }, cancellationToken);

            if (availability == null)
                return false;

            if (availability.IsAvailableForPeriod == false)
                return false;

            return await _reservationRepository.SetReservationForPeriodAsync(request, cancellationToken);
        }
    }
}
