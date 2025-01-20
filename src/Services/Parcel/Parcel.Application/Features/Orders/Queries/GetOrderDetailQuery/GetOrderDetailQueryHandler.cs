using AutoMapper;
using CSharpFunctionalExtensions;
using MediatR;
using Microsoft.AspNetCore.Http;
using Parcel.Application.Contracts.Persistance;
using Parcel.Application.Helpers;
using PD.Shared.Models;

namespace Parcel.Application.Features.Orders.Queries.GetOrderDetailQuery
{
    public class GetOrderDetailQueryHandler : IRequestHandler<GetOrderDetailQuery, Result<OrderDetailDto, DomainError>>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public GetOrderDetailQueryHandler(IOrderRepository orderRepository, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<Result<OrderDetailDto, DomainError>> Handle(GetOrderDetailQuery request, CancellationToken cancellationToken)
        {
            var token = _httpContextAccessor.HttpContext?.Request.Headers["Authorization"].ToString();
            var userId = JwtHelper.GetUserIdFromToken(token);

            if (userId is null)
            {
                return Result.Failure<OrderDetailDto, DomainError>(DomainError.BusinessError("User information is not correct."));
            }

            var order = await _orderRepository.GetFirstOrDefaultAsync(o => (o.UserId == userId.Value || o.CurierId == userId.Value) && o.Id == request.OrderId && !o.IsDeleted && o.IsActive);

            if (order == null)
                return Result.Failure<OrderDetailDto, DomainError>(DomainError.BusinessError("Order not found related to the user."));

            var orderDetailDto = _mapper.Map<OrderDetailDto>(order);
            return Result.Success<OrderDetailDto, DomainError>(orderDetailDto);
        }
    }
}
