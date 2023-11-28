using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Alten.HotelChallenge.Application.UseCases.GetRoomAvailability
{
    public class GetRoomAvailabilityInput : IRequest<GetRoomAvailabilityOutput>
    {
        [Required]
        public long RoomId { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
    }
}
