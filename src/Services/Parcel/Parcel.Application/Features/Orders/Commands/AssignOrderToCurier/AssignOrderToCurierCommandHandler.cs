using AutoMapper;
using CSharpFunctionalExtensions;
using MediatR;
using Parcel.Application.Contracts.Persistance;
using PD.Shared.Enums;
using PD.Shared.Models;

namespace Parcel.Application.Features.Orders.Commands.AssignOrderToCurier
{
    public class AssignOrderToCurierCommandHandler : IRequestHandler<AssignOrderToCurierCommand, Result<AssignOrderToCurierDto, DomainError>>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public AssignOrderToCurierCommandHandler(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public async Task<Result<AssignOrderToCurierDto, DomainError>> Handle(AssignOrderToCurierCommand request, CancellationToken cancellationToken)
        {
            var order = await _orderRepository.GetFirstOrDefaultAsync(o => o.Id == request.OrderId);

            if (order == null)
                return Result.Failure<AssignOrderToCurierDto, DomainError>(DomainError.BusinessError("Order not found."));

            if (order.Status == (int)OrderStatus.DELIVEREDCURIER || order.Status == (int)OrderStatus.CANCELED)
                return Result.Failure<AssignOrderToCurierDto, DomainError>(DomainError.BusinessError("Canceled or Delivered order's information cannot be assign."));

            order.CurierId = request.CurierId; // can implement RabbitMQ MassTransit to ask Authentication service, Curier with the id is available
            order.Status = (int)OrderStatus.DELIVEREDCURIER;

            await _orderRepository.UpdateAsync(order);

            var orderDetailDto = _mapper.Map<AssignOrderToCurierDto>(order);

            return Result.Success<AssignOrderToCurierDto, DomainError>(orderDetailDto);
        }
    }
}
