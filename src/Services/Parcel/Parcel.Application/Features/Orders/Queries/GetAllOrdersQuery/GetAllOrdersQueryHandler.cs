using AutoMapper;
using CSharpFunctionalExtensions;
using MediatR;
using Parcel.Application.Contracts.Persistance;
using Parcel.Application.Features.Orders.Queries.GetOrdersListQuery;
using PD.Shared.Models;

namespace Parcel.Application.Features.Orders.Queries.GetAllOrdersQuery
{
    public class GetAllOrdersQueryHandler : IRequestHandler<GetAllOrdersQuery, Result<List<OrdersDto>, DomainError>>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public GetAllOrdersQueryHandler(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public async Task<Result<List<OrdersDto>, DomainError>> Handle(GetAllOrdersQuery request, CancellationToken cancellationToken)
        {
            var orderList = await _orderRepository.GetAsync(o => o.IsActive && !o.IsDeleted);

            if (orderList == null)
                return Result.Failure<List<OrdersDto>, DomainError>(DomainError.BusinessError("There is not any orders."));

            var orderDto = _mapper.Map<List<OrdersDto>>(orderList);
            return Result.Success<List<OrdersDto>, DomainError>(orderDto);
        }
    }
}
