﻿using CSharpFunctionalExtensions;
using MediatR;
using PD.Shared.Models;

namespace Parcel.Application.Features.Orders.Queries.GetOrdersListQuery
{
    public class GetOrdersListQuery : IRequest<IResult<List<OrdersDto>, DomainError>>
    {
    }
}
