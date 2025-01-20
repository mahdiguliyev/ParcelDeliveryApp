using CSharpFunctionalExtensions;
using MediatR;
using PD.Shared.Models;
using System.ComponentModel.DataAnnotations;

namespace Parcel.Application.Features.Orders.Queries.GetOrderDetailQuery
{
    public class GetOrderDetailQuery : IRequest<IResult<OrderDetailDto, DomainError>>
    {
        [Required(ErrorMessage = "Order id is required.")]
        public Guid OrderId { get; set; }
    }
}
