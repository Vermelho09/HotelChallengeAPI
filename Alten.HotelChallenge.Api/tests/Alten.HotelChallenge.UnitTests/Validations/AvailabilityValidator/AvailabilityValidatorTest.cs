using Gwtdo;
using Xunit;

namespace Alten.HotelChallenge.UnitTests.Validations.AvailabilityValidator
{
    public class AvailabilityValidatorTest : Feature<AvailabilityValidatorFixture>, IClassFixture<AvailabilityValidatorFixture>
    {
        public AvailabilityValidatorTest(AvailabilityValidatorFixture fixture)
        {
            SetFixture(fixture);
            fixture.Setup();
        }

        [Fact]
        public void Validate_payload_sucessfully()
        {
            GIVEN
                .I_have_a_validator().And
                .I_have_a_valid_payload();

            WHEN
                .I_validate_payload();

            THEN
                .My_validation_returns_sucess().And
                .Without_errors();
        }

        [Fact]
        public void Validate_payload_with_invalid_period()
        {
            GIVEN
                .I_have_a_validator().And
                .I_have_a_payload_with_invalid_period();

            WHEN
                .I_validate_payload();

            THEN
                .My_validation_returns_unsucess().And
                .With_errors();

        }

        [Fact]
        public void Validate_payload_with_reservation_date_for_next_year()
        {
            GIVEN
                .I_have_a_validator().And
                .I_have_a_payload_with_dates_for_next_year();

            WHEN
                .I_validate_payload();

            THEN
                .My_validation_returns_unsucess().And
                .With_errors();
        }

        [Fact]
        public void Validate_payload_with_request_for_more_then_3_days()
        {
            GIVEN
                .I_have_a_validator().And
                .I_have_a_payload_with_a_period_for_4_days();

            WHEN
                .I_validate_payload();

            THEN
                .My_validation_returns_unsucess().And
                .With_errors();
        }
    }
}

