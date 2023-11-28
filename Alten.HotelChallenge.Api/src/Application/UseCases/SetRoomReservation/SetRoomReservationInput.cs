using MediatR;

namespace Alten.HotelChallenge.Application.UseCases.SetRoomReservation
{
    public class SetRoomReservationInput : IRequest<bool>
    {
        public int RoomId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string MainGuestDocument { get; set; } = null!;
        public string MainGuestName { get; set; } = null!;
        public string MainGuestEmail { get; set; } = null!;
    }
}
