using AutoMapper;
using CSharpFunctionalExtensions;
using MediatR;
using Parcel.Application.Contracts.Persistance;
using PD.Shared.Enums;
using PD.Shared.Models;

namespace Parcel.Application.Features.Orders.Queries.TrakOrderQuery
{
    public class TrakOrderQueryHandler : IRequestHandler<TrakOrderQuery, Result<TrackOrderDto, DomainError>>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public TrakOrderQueryHandler(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public async Task<Result<TrackOrderDto, DomainError>> Handle(TrakOrderQuery request, CancellationToken cancellationToken)
        {
            var order = await _orderRepository.GetFirstOrDefaultAsync(o => o.Id == request.OrderId && !o.IsDeleted && o.IsActive);

            if (order == null)
                return Result.Failure<TrackOrderDto, DomainError>(DomainError.BusinessError("Order not found."));

            if(order.Status != (int)OrderStatus.DELIVEREDCURIER)
                return Result.Failure<TrackOrderDto, DomainError>(DomainError.BusinessError("Order is not delivered to curier."));

            var trackOrderDto = _mapper.Map<TrackOrderDto>(order);
            return Result.Success<TrackOrderDto, DomainError>(trackOrderDto);
        }
    }
}
