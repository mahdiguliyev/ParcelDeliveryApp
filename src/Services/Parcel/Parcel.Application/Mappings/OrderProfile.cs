using AutoMapper;
using Parcel.Application.Features.Orders.Commands.AssignOrderToCurier;
using Parcel.Application.Features.Orders.Commands.CreateOrder;
using Parcel.Application.Features.Orders.Commands.UpdateCurrentCoordinatesOrder;
using Parcel.Application.Features.Orders.Queries.GetOrderDetailQuery;
using Parcel.Application.Features.Orders.Queries.GetOrdersListQuery;
using Parcel.Application.Features.Orders.Queries.TrakOrderQuery;
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
            CreateMap<Order, AssignOrderToCurierDto>().ReverseMap();
            CreateMap<Order, UpdateCurrentCoordinatesOrderDto>().ReverseMap();
            CreateMap<Order, TrackOrderDto>().ReverseMap();
        }
    }
}
