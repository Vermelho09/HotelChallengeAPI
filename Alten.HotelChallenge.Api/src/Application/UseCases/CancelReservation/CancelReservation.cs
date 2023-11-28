using Alten.HotelChallenge.Application.Repositories;

namespace Alten.HotelChallenge.Application.UseCases.CancelReservation
{
    public class CancelReservation : ICancelReservation
    {
        private readonly IReservationRepository _reservationRepository;

        public CancelReservation(IReservationRepository reservationRepository)
        {
            _reservationRepository = reservationRepository;
        }

        public async Task<bool> Handle(CancelReservationInput request, CancellationToken cancellationToken)
        {
            return await _reservationRepository.CancelReservationAsync(request, cancellationToken);
        }
    }
}
