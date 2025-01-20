using AutoMapper;
using CSharpFunctionalExtensions;
using MediatR;
using Microsoft.AspNetCore.Http;
using Parcel.Application.Contracts.Persistance;
using Parcel.Application.Helpers;
using PD.Shared.Enums;
using PD.Shared.Models;

namespace Parcel.Application.Features.Orders.Commands.ChangeStatusOrder
{
    public class ChangeStatusOrderCommandHandler : IRequestHandler<ChangeStatusOrderCommand, Result<Guid, DomainError>>
    {
        private readonly IOrderRepository _orderRepository;

        public ChangeStatusOrderCommandHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<Result<Guid, DomainError>> Handle(ChangeStatusOrderCommand request, CancellationToken cancellationToken)
        {
            var order = await _orderRepository.GetFirstOrDefaultAsync(o => o.Id == request.OrderId);

            if (order == null)
                return Result.Failure<Guid, DomainError>(DomainError.BusinessError("Order not found."));

            if (order.Status == (int)request.Status)
                return Result.Failure<Guid, DomainError>(DomainError.BusinessError("Status of order is the status, you want to change."));

            order.Status = (int)request.Status;

            await _orderRepository.UpdateAsync(order);

            return Result.Success<Guid, DomainError>(order.Id);
        }
    }
}
