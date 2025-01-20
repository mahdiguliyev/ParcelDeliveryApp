using AutoMapper;
using CSharpFunctionalExtensions;
using MediatR;
using Microsoft.AspNetCore.Http;
using Parcel.Application.Contracts.Persistance;
using Parcel.Application.Helpers;
using PD.Shared.Enums;
using PD.Shared.Models;

namespace Parcel.Application.Features.Orders.Commands.RejectOrCompleteOrder
{
    public class RejectOrCompleteOrderCommandHandler : IRequestHandler<RejectOrCompleteOrderCommand, Result<RejectOrCompleteOrderDto, DomainError>>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public RejectOrCompleteOrderCommandHandler(IOrderRepository orderRepository, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<Result<RejectOrCompleteOrderDto, DomainError>> Handle(RejectOrCompleteOrderCommand request, CancellationToken cancellationToken)
        {
            var token = _httpContextAccessor.HttpContext?.Request.Headers["Authorization"].ToString();
            var userId = JwtHelper.GetUserIdFromToken(token);

            if (userId is null)
            {
                return Result.Failure<RejectOrCompleteOrderDto, DomainError>(DomainError.BusinessError("User information is not correct."));
            }

            var order = await _orderRepository.GetFirstOrDefaultAsync(o => o.Id == request.OrderId && o.CurierId == userId);

            if (order == null)
                return Result.Failure<RejectOrCompleteOrderDto, DomainError>(DomainError.BusinessError("Order not found."));

            if (order.Status != (int)OrderStatus.DELIVEREDCURIER)
                return Result.Failure<RejectOrCompleteOrderDto, DomainError>(DomainError.BusinessError("Order is not delivered to a curier."));

            if (!Enum.IsDefined(typeof(OrderStatus), request.Status))
                return Result.Failure<RejectOrCompleteOrderDto, DomainError>(DomainError.BusinessError("Status is not defined."));

            order.CurierId = null;
            order.Status = (int)request.Status;
            order.RejectedOrCompletedReason = request.RejectedOrCompletedReason;

            await _orderRepository.UpdateAsync(order);
            var rejectOrCompleteOrderDto = _mapper.Map<RejectOrCompleteOrderDto>(order);

            return Result.Success<RejectOrCompleteOrderDto, DomainError>(rejectOrCompleteOrderDto);
        }
    }
}
