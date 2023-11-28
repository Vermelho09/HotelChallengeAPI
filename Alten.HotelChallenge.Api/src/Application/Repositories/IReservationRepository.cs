using Alten.HotelChallenge.Application.UseCases.CancelReservation;
using Alten.HotelChallenge.Application.UseCases.ModifyReservation;
using Alten.HotelChallenge.Application.UseCases.SetRoomReservation;

namespace Alten.HotelChallenge.Application.Repositories
{
    public interface IReservationRepository
    {
        Task<bool> SetReservationForPeriodAsync(SetRoomReservationInput getRoomAvailabilityInput, CancellationToken cancellationToken);

        Task<bool> ModifyReservationAsync(ModifyReservationInput input, CancellationToken cancellationToken);

        Task<bool> CancelReservationAsync(CancelReservationInput input, CancellationToken cancellationToken);
    }
}
