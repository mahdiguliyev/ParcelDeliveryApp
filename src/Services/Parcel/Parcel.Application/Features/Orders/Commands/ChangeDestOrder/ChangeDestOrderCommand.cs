using CSharpFunctionalExtensions;
using MediatR;
using Parcel.Application.Features.Orders.Queries.GetOrderDetailQuery;
using PD.Shared.Models;
using System.ComponentModel.DataAnnotations;

namespace Parcel.Application.Features.Orders.Commands.ChangeDestOrder
{
    public class ChangeDestOrderCommand : IRequest<Result<OrderDetailDto, DomainError>>
    {
        [Required(ErrorMessage = "Order id is required.")]
        public Guid OrderId { get; set; }

        [Required(ErrorMessage = "Destination address is required.")]
        [StringLength(200, ErrorMessage = "Destination address must not exceed 200 characters.")]
        public string DestinationAddress { get; set; }

        [Required(ErrorMessage = "Coortinates is required.")]
        [StringLength(50, ErrorMessage = "Coordinates must not exceed 50 characters.")]
        public string Coortinates { get; set; }
    }
}
