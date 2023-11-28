using Alten.HotelChallenge.Application.Repositories;
using Alten.HotelChallenge.Application.UseCases.CancelReservation;
using Alten.HotelChallenge.Application.UseCases.ModifyReservation;
using Alten.HotelChallenge.Application.UseCases.SetRoomReservation;
using DBFirst.Sample.Project.Models;

namespace Alten.HotelChallenge.SQLServer.Repositories
{
    public class ReservationRepository : Repository<Reservation>, IReservationRepository
    {
        public ReservationRepository(AltenContext altenDbContext) : base(altenDbContext)
        {

        }

        public async Task<bool> SetReservationForPeriodAsync(SetRoomReservationInput input, CancellationToken cancellationToken)
        {
            var entityValue = new Reservation()
            {
                RoomId = input.RoomId,
                StartDate = input.StartDate.Date,
                EndDate = input.EndDate.Date,
                MainGuestDocument = input.MainGuestDocument,
                MainGuestName = input.MainGuestName,
                MainGuestEmail = input.MainGuestEmail,
                IsConfirmed = true
            };
            await Context.Reservation.AddAsync(entityValue, cancellationToken);
            await Context.SaveChangesAsync(cancellationToken);
            return true;
        }

        public async Task<bool> ModifyReservationAsync(ModifyReservationInput input, CancellationToken cancellationToken)
        {
            var updatedReservation = new Reservation()
            {
                Id = input.ReservationId,
                RoomId = input.RoomId,
                StartDate = input.StartDate.Date,
                EndDate = input.EndDate.Date,
                MainGuestDocument = input.MainGuestDocument,
                MainGuestName = input.MainGuestName,
                MainGuestEmail = input.MainGuestEmail,
                IsConfirmed = true
            };
            Context.Reservation.Update(updatedReservation);
            await Context.SaveChangesAsync(cancellationToken);
            return true;
        }

        public async Task<bool> CancelReservationAsync(CancelReservationInput input, CancellationToken cancellationToken)
        {
            var reservationToCancel = new Reservation()
            {
                Id = input.ReservationId,
                IsConfirmed = false
            };
            Context.Reservation.Attach(reservationToCancel);
            Context.Entry(reservationToCancel).Property(x => x.IsConfirmed).IsModified = true;
            await Context.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}
