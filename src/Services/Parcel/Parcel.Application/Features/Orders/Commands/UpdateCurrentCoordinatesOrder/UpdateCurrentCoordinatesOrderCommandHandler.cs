using AutoMapper;
using CSharpFunctionalExtensions;
using MediatR;
using Parcel.Application.Contracts.Persistance;
using PD.Shared.Enums;
using PD.Shared.Models;

namespace Parcel.Application.Features.Orders.Commands.UpdateCurrentCoordinatesOrder
{
    public class UpdateCurrentCoordinatesOrderCommandHandler : IRequestHandler<UpdateCurrentCoordinatesOrderCommand, Result<UpdateCurrentCoordinatesOrderDto, DomainError>>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public UpdateCurrentCoordinatesOrderCommandHandler(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public async Task<Result<UpdateCurrentCoordinatesOrderDto, DomainError>> Handle(UpdateCurrentCoordinatesOrderCommand request, CancellationToken cancellationToken)
        {
            var order = await _orderRepository.GetFirstOrDefaultAsync(o => o.Id == request.OrderId && !o.IsDeleted && o.IsActive);

            if (order == null)
                return Result.Failure<UpdateCurrentCoordinatesOrderDto, DomainError>(DomainError.BusinessError("Order not found."));

            if (order.Status != (int)OrderStatus.DELIVEREDCURIER)
                return Result.Failure<UpdateCurrentCoordinatesOrderDto, DomainError>(DomainError.BusinessError("Order is not dilevered to curier."));

            order.CurrentCoortinates = request.CurrentCoortinates;

            await _orderRepository.UpdateAsync(order);

            var orderDetailDto = _mapper.Map<UpdateCurrentCoordinatesOrderDto>(order);

            return Result.Success<UpdateCurrentCoordinatesOrderDto, DomainError>(orderDetailDto);
        }
    }
}
