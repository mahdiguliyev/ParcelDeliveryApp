using AutoMapper;
using CSharpFunctionalExtensions;
using MediatR;
using Microsoft.AspNetCore.Http;
using Parcel.Application.Contracts.Persistance;
using Parcel.Application.Helpers;
using Parcel.Domain.Entities;
using PD.Shared.Models;

namespace Parcel.Application.Features.Orders.Commands.CreateOrder
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, Result<CreateOrderCommand, DomainError>>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CreateOrderCommandHandler(IOrderRepository orderRepository, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<Result<CreateOrderCommand, DomainError>> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var token = _httpContextAccessor.HttpContext?.Request.Headers["Authorization"].ToString();
            var userId = JwtHelper.GetUserIdFromToken(token);

            if (userId is null)
            {
                return Result.Failure<CreateOrderCommand, DomainError>(DomainError.BusinessError("User information is not correct."));
            }

            var orderEntity = _mapper.Map<Order>(request);

            orderEntity.UserId = userId.Value;

            var newOrder = await _orderRepository.AddAsync(orderEntity);

            if (newOrder is null)
            {
                return Result.Failure<CreateOrderCommand, DomainError>(DomainError.BusinessError("Order cannot created."));
            }

            return Result.Success<CreateOrderCommand, DomainError>(request);
        }
    }
}
