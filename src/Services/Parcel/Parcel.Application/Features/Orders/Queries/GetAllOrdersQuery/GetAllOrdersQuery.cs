using CSharpFunctionalExtensions;
using MediatR;
using Parcel.Application.Features.Orders.Queries.GetOrdersListQuery;
using PD.Shared.Models;

namespace Parcel.Application.Features.Orders.Queries.GetAllOrdersQuery
{
    public class GetAllOrdersQuery : IRequest<Result<List<OrdersDto>, DomainError>>
    {
    }
}
