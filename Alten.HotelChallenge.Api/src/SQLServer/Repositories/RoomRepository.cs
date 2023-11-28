using Alten.HotelChallenge.Application.Repositories;
using Alten.HotelChallenge.Application.UseCases.GetRoomAvailability;
using DBFirst.Sample.Project.Models;
using Microsoft.EntityFrameworkCore;

namespace Alten.HotelChallenge.SQLServer.Repositories
{
    public class RoomRepository : Repository<Room>, IRoomRepository
    {
        public RoomRepository(AltenContext altenDbContext) : base(altenDbContext)
        {

        }

        public async Task<GetRoomAvailabilityOutput> GetAvailabilityForPeriodAsync(GetRoomAvailabilityInput input, CancellationToken cancellationToken)
        {
            string returnMessage;
            var isRoomValid = await Context.Room.AnyAsync(a => a.Id == input.RoomId && a.IsActive == true, cancellationToken);

            if (isRoomValid == false)
                return new GetRoomAvailabilityOutput { IsAvailableForPeriod = isRoomValid, Message = "Room not active or it does not exist." };

            var hasReservation = await Context.Reservation.AnyAsync(db =>
                        db.RoomId == input.RoomId
                        && db.IsConfirmed == true
                        && ((input.StartDate >= db.StartDate && input.StartDate <= db.EndDate)
                        || (input.EndDate >= db.StartDate && input.EndDate <= db.EndDate)), cancellationToken); ;

            if (hasReservation == true)
                returnMessage = "Room is booked for the selected period.";
            else
                returnMessage = "Room is available!";


            return new GetRoomAvailabilityOutput
            {
                IsAvailableForPeriod = !hasReservation,
                Message = returnMessage
            };
        }
    }
}
