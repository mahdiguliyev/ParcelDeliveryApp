using AutoMapper;
using CSharpFunctionalExtensions;
using MediatR;
using Microsoft.AspNetCore.Http;
using Parcel.Application.Contracts.Persistance;
using Parcel.Application.Helpers;
using PD.Shared.Models;

namespace Parcel.Application.Features.Orders.Queries.GetOrdersListQuery
{
    public class GetOrdersListQueryHandler : IRequestHandler<GetOrdersListQuery, Result<List<OrdersDto>, DomainError>>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public GetOrdersListQueryHandler(IOrderRepository orderRepository, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<Result<List<OrdersDto>, DomainError>> Handle(GetOrdersListQuery request, CancellationToken cancellationToken)
        {
            var token = _httpContextAccessor.HttpContext?.Request.Headers["Authorization"].ToString();
            var userId = JwtHelper.GetUserIdFromToken(token);

            if (userId is null)
            {
                return Result.Failure<List<OrdersDto>, DomainError>(DomainError.BusinessError("User information is not correct."));
            }

            var orderList = await _orderRepository.GetOrdersByUserNameAsync(userId.Value);

            if (orderList == null)
                return Result.Failure<List<OrdersDto>, DomainError>(DomainError.BusinessError("There is not any orders."));

            var orderDto = _mapper.Map<List<OrdersDto>>(orderList);
            return Result.Success<List<OrdersDto>, DomainError>(orderDto);
        }
    }
}
