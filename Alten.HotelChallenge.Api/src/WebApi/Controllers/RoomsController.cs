using Alten.HotelChallenge.Application.UseCases.GetRoomAvailability;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
namespace Alten.HotelChallenge.WebApi.Controllers

{
    [ApiController]
    [Route("[controller]")]
    public class RoomsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly AbstractValidator<GetRoomAvailabilityInput> _validationRules;

        public RoomsController(IMediator mediator, AbstractValidator<GetRoomAvailabilityInput> validationRules)
        {
            _mediator = mediator;
            _validationRules = validationRules;
        }

        [HttpGet("Availability")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetRoomAvailabilityOutput))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetRoomAvailability([FromQuery] GetRoomAvailabilityInput input, CancellationToken cancellationToken)
        {
            var validationResult = await _validationRules.ValidateAsync(input, cancellationToken);

            if (validationResult.IsValid)
            {
                var result = await _mediator.Send(input, cancellationToken);
                return StatusCode(StatusCodes.Status200OK, result);
            }
            else
            {
                return BadRequest(validationResult.Errors);
            }

        }
    }
}
