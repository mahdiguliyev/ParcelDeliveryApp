using AutoMapper;
using CSharpFunctionalExtensions;
using MediatR;
using Microsoft.AspNetCore.Http;
using Parcel.Application.Contracts.Persistance;
using Parcel.Application.Helpers;
using PD.Shared.Enums;
using PD.Shared.Models;

namespace Parcel.Application.Features.Orders.Commands.CancelOrder
{
    public class CancelOrderCommandHandler : IRequestHandler<CancelOrderCommand, Result<Guid, DomainError>>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CancelOrderCommandHandler(IOrderRepository orderRepository, IHttpContextAccessor httpContextAccessor)
        {
            _orderRepository = orderRepository;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<Result<Guid, DomainError>> Handle(CancelOrderCommand request, CancellationToken cancellationToken)
        {
            var token = _httpContextAccessor.HttpContext?.Request.Headers["Authorization"].ToString();
            var userId = JwtHelper.GetUserIdFromToken(token);

            if (userId is null)
            {
                return Result.Failure<Guid, DomainError>(DomainError.BusinessError("User information is not correct."));
            }

            var order = await _orderRepository.GetFirstOrDefaultAsync(o => o.UserId == userId.Value && o.Id == request.OrderId);

            if (order == null)
                return Result.Failure<Guid, DomainError>(DomainError.BusinessError("Order not found related to the user."));

            if (order.Status == (int)OrderStatus.DELIVEREDCURIER || order.Status == (int)OrderStatus.CANCELED)
                return Result.Failure<Guid, DomainError>(DomainError.BusinessError("Canceled or Delivered order's information cannot be changed."));

            order.Status = (int)OrderStatus.CANCELED;

            await _orderRepository.UpdateAsync(order);

            return Result.Success<Guid, DomainError>(order.Id);
        }
    }
}
