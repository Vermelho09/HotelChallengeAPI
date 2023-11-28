using Alten.HotelChallenge.Application.UseCases.CancelReservation;
using Alten.HotelChallenge.Application.UseCases.ModifyReservation;
using Alten.HotelChallenge.Application.UseCases.SetRoomReservation;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Alten.HotelChallenge.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReservationsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly AbstractValidator<SetRoomReservationInput> _validationRules;

        public ReservationsController(IMediator mediator, AbstractValidator<SetRoomReservationInput> validationRules)
        {
            _mediator = mediator;
            _validationRules = validationRules;
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> SetRoomReservation([FromBody] SetRoomReservationInput input, CancellationToken cancellationToken)
        {
            var validationResult = await _validationRules.ValidateAsync(input, cancellationToken);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            var result = await _mediator.Send(input, cancellationToken);

            if (result == false)
                return StatusCode(StatusCodes.Status400BadRequest, result);

            return StatusCode(StatusCodes.Status201Created, result);
        }

        [HttpPatch]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> AlterRoomReservation([FromBody] ModifyReservationInput input, CancellationToken cancellationToken)
        {
            var validationResult = await _validationRules.ValidateAsync(input, cancellationToken);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            var result = await _mediator.Send(input, cancellationToken);

            if (result == false)
                return StatusCode(StatusCodes.Status400BadRequest, result);

            return StatusCode(StatusCodes.Status200OK, result);
        }

        [HttpDelete("{reservationId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CancelReservation(long reservationId, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new CancelReservationInput { ReservationId = reservationId }, cancellationToken);

            if (result == false)
                return StatusCode(StatusCodes.Status400BadRequest, result);

            return StatusCode(StatusCodes.Status200OK, result);
        }
    }
}
