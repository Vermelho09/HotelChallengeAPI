namespace Alten.HotelChallenge.Application.UseCases.GetRoomAvailability
{
    public class GetRoomAvailabilityOutput
    {
        public bool IsAvailableForPeriod { get; set; }
        public string Message { get; set; }
    }
}
