using CSharpFunctionalExtensions;
using MediatR;
using PD.Shared.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Parcel.Application.Features.Orders.Commands.CancelOrder
{
    public class CancelOrderCommand : IRequest<Result<Guid, DomainError>>
    {
        [Required(ErrorMessage = "Order id is required.")]
        [DefaultValue("")]
        public Guid OrderId { get; set; }
    }
}
