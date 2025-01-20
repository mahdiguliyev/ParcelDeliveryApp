using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Parcel.Application.Features.Orders.Commands.AssignOrderToCurier;
using Parcel.Application.Features.Orders.Commands.CancelOrder;
using Parcel.Application.Features.Orders.Commands.ChangeDestOrder;
using Parcel.Application.Features.Orders.Commands.ChangeStatusOrder;
using Parcel.Application.Features.Orders.Commands.CreateOrder;
using Parcel.Application.Features.Orders.Queries.GetAllOrdersQuery;
using Parcel.Application.Features.Orders.Queries.GetOrderDetailQuery;
using Parcel.Application.Features.Orders.Queries.GetOrdersListQuery;
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
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Authorize(Roles = "User")]
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

        [HttpGet("getorders")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Authorize(Roles = "User")]
        public async Task<IActionResult> GetOrders()
        {
            GetOrdersListQuery command = new GetOrdersListQuery();
            var result = await _mediator.Send(command);

            return result.IsSuccess ?
                Ok(ApiResponse<List<OrdersDto>>.Success(result.Value)) :
                BadRequest(ApiResponse<List<OrdersDto>>.Failure(result.Error.ErrorMessage));
        }

        [HttpGet("getallorders")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAllOrders()
        {
            GetAllOrdersQuery command = new GetAllOrdersQuery();
            var result = await _mediator.Send(command);

            return result.IsSuccess ?
                Ok(ApiResponse<List<OrdersDto>>.Success(result.Value)) :
                BadRequest(ApiResponse<List<OrdersDto>>.Failure(result.Error.ErrorMessage));
        }

        [HttpGet("getorderdetail")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Authorize(Roles = "User")]
        public async Task<IActionResult> GetOrderDetail(GetOrderDetailQuery command)
        {
            var result = await _mediator.Send(command);

            return result.IsSuccess ?
                Ok(ApiResponse<OrderDetailDto>.Success(result.Value)) :
                BadRequest(ApiResponse<OrderDetailDto>.Failure(result.Error.ErrorMessage));
        }

        [HttpPut("updateorderdest")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Authorize(Roles = "User")]
        public async Task<IActionResult> UpdateOrderDest(ChangeDestOrderCommand command)
        {
            var result = await _mediator.Send(command);

            return result.IsSuccess ?
                Ok(ApiResponse<OrderDetailDto>.Success(result.Value)) :
                BadRequest(ApiResponse<OrderDetailDto>.Failure(result.Error.ErrorMessage));
        }

        [HttpPut("cancelorder")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Authorize(Roles = "User")]
        public async Task<IActionResult> CancelOrder(CancelOrderCommand command)
        {
            var result = await _mediator.Send(command);

            return result.IsSuccess ?
                Ok(ApiResponse<Guid>.Success(result.Value)) :
                BadRequest(ApiResponse<Guid>.Failure(result.Error.ErrorMessage));
        }

        [HttpPut("changeorderstatus")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> ChangeOrderStatus(ChangeStatusOrderCommand command)
        {
            var result = await _mediator.Send(command);

            return result.IsSuccess ?
                Ok(ApiResponse<Guid>.Success(result.Value)) :
                BadRequest(ApiResponse<Guid>.Failure(result.Error.ErrorMessage));
        }

        [HttpPost("assignordertocurier")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AssignOrderToCurier(AssignOrderToCurierCommand command)
        {
            var result = await _mediator.Send(command);

            return result.IsSuccess ?
                Ok(ApiResponse<AssignOrderToCurierDto>.Success(result.Value)) :
                BadRequest(ApiResponse<AssignOrderToCurierDto>.Failure(result.Error.ErrorMessage));
        }
    }
}
