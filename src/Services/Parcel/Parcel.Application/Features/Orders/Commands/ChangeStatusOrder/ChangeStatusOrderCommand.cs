using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using PD.Shared.Enums;
using CSharpFunctionalExtensions;
using MediatR;
using PD.Shared.Models;

namespace Parcel.Application.Features.Orders.Commands.ChangeStatusOrder
{
    public class ChangeStatusOrderCommand : IRequest<Result<Guid, DomainError>>
    {
        [Required(ErrorMessage = "Order id is required.")]
        [DefaultValue("")]
        public Guid OrderId { get; set; }

        [Required(ErrorMessage = "Status is required.")]
        public OrderStatus Status { get; set; }
    }
}
