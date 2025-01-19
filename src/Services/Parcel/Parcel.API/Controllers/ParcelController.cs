using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Parcel.Application.Features.Orders.Commands.CreateOrder;
using PD.Shared.Models;

namespace Parcel.API.Controllers
{
    [Route("api/parcel")]
    [ApiController]
    public class ParcelController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ParcelController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("createorder")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Authorize]
        public async Task<IActionResult> CreateOrder(CreateOrderCommand command)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _mediator.Send(command);

            return result.IsSuccess ?
                Ok(ApiResponse<CreateOrderCommand>.Success(result.Value)) :
                BadRequest(ApiResponse<CreateOrderCommand>.Failure(result.Error.ErrorMessage));
        }

        [HttpGet("{id}")]
        [Authorize]
        public IActionResult GetParcel(string id)
        {
            return Ok(id);
        }
    }
}
