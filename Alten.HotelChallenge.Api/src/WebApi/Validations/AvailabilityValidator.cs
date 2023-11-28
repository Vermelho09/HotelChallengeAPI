using Alten.HotelChallenge.Application.UseCases.GetRoomAvailability;
using FluentValidation;

namespace Alten.HotelChallenge.WebApi.Validations
{
    public class AvailabilityValidator : AbstractValidator<GetRoomAvailabilityInput>
    {
        public AvailabilityValidator()
        {
            RuleFor(x => x.StartDate).GreaterThanOrEqualTo(DateTime.Now.Date.AddDays(1))
                .WithMessage("Must be a future date.");

            RuleFor(x => x.EndDate).GreaterThanOrEqualTo(DateTime.Now.Date.AddDays(1))
                .WithMessage("Must be a future date.");

            RuleFor(x => x.EndDate).GreaterThanOrEqualTo(x => x.StartDate)
                .WithMessage("Must be a valid period.");

            RuleFor(x => x.EndDate).LessThan(DateTime.Now.AddDays(30))
                .WithMessage("Room only available for reservation in less than 30 days in advance.");

            RuleFor(x => x.StartDate.Date.AddDays(3)).GreaterThan(x => x.EndDate)
                .WithMessage("Rooms not available for more than 3 days.");
        }
    }
}
