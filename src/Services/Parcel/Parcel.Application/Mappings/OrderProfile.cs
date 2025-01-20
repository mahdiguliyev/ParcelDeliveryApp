using AutoMapper;
using Parcel.Application.Features.Orders.Commands.CreateOrder;
using Parcel.Application.Features.Orders.Queries.GetOrderDetailQuery;
using Parcel.Application.Features.Orders.Queries.GetOrdersListQuery;
using Parcel.Domain.Entities;

namespace Parcel.Application.Mappings
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<Order, CreateOrderCommand>().ReverseMap();
            CreateMap<Order, OrdersDto>().ReverseMap();
            CreateMap<Order, OrderDetailDto>().ReverseMap();
        }
    }
}
