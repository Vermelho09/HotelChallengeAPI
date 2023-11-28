using Alten.HotelChallenge.Application.UseCases.GetRoomAvailability;
using FluentAssertions;
using FluentValidation.Results;
using Gwtdo;
using System;
using System.Threading;
using V = Alten.HotelChallenge.WebApi.Validations;

namespace Alten.HotelChallenge.UnitTests.Validations.AvailabilityValidator
{

    using Act = Act<AvailabilityValidatorFixture>;
    using Arrange = Arrange<AvailabilityValidatorFixture>;
    using Assert = Assert<AvailabilityValidatorFixture>;
    public class AvailabilityValidatorFixture : IFixture
    {
        internal GetRoomAvailabilityInput Input;
        internal ValidationResult Result;
        internal V.AvailabilityValidator Validator;
        internal CancellationToken CancellationToken;

        public void Setup()
        {
            CancellationToken = new CancellationToken();
        }
    }

    internal static class Setup
    {
        public static Arrange I_have_a_validator(this Arrange fixture)
        {
            return fixture.Setup(f => f.Validator = new V.AvailabilityValidator());
        }

        public static Arrange I_have_a_valid_payload(this Arrange fixture)
        {
            return fixture.Setup(f =>
                f.Input = new GetRoomAvailabilityInput { RoomId = 1, StartDate = DateTime.Now.AddDays(2).Date, EndDate = DateTime.Now.AddDays(3).Date }
            );
        }

        public static Arrange I_have_a_payload_with_invalid_period(this Arrange fixture)
        {
            return fixture.Setup(f =>
                f.Input = new GetRoomAvailabilityInput { RoomId = 1, StartDate = DateTime.Now.Date, EndDate = DateTime.Now.AddDays(-1).Date }
            );
        }

        public static Arrange I_have_a_payload_with_dates_for_next_year(this Arrange fixture)
        {
            return fixture.Setup(f =>
                f.Input = new GetRoomAvailabilityInput { RoomId = 1, StartDate = DateTime.Now.AddYears(1).Date, EndDate = DateTime.Now.AddYears(1).Date }
            );
        }

        public static Arrange I_have_a_payload_with_a_period_for_4_days(this Arrange fixture)
        {
            return fixture.Setup(f =>
                f.Input = new GetRoomAvailabilityInput { RoomId = 1, StartDate = DateTime.Now.AddDays(2).Date, EndDate = DateTime.Now.AddDays(6).Date }
            );
        }
    }

    internal static class Exercise
    {
        public static Act I_validate_payload(this Act fixture)
        {
            return fixture.It(async f =>
            {
                f.Result = await f.Validator.ValidateAsync(f.Input, f.CancellationToken);
            });
        }
    }

    internal static class Verify
    {
        public static Assert My_validation_returns_sucess(this Assert fixture)
        {
            return fixture.Expect(f => f.Result.IsValid.Should().BeTrue());
        }

        public static Assert Without_errors(this Assert fixture)
        {
            return fixture.Expect(f => f.Result.Errors.Should().HaveCount(0));
        }

        public static Assert My_validation_returns_unsucess(this Assert fixture)
        {
            return fixture.Expect(f => f.Result.IsValid.Should().BeFalse());
        }

        public static Assert With_errors(this Assert fixture)
        {
            return fixture.Expect(f => f.Result.Errors.Should().HaveCountGreaterThan(0));
        }
    }
}
