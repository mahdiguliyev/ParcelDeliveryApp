using AutoMapper;
using Parcel.Application.Features.Orders.Commands.CreateOrder;
using Parcel.Domain.Entities;

namespace Parcel.Application.Mappings
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<Order, CreateOrderCommand>().ReverseMap();
        }
    }
}
