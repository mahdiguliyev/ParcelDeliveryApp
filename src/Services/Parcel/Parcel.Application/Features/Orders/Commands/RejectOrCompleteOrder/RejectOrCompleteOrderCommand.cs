using CSharpFunctionalExtensions;
using MediatR;
using PD.Shared.Enums;
using PD.Shared.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Parcel.Application.Features.Orders.Commands.RejectOrCompleteOrder
{
    public class RejectOrCompleteOrderCommand : IRequest<Result<RejectOrCompleteOrderDto, DomainError>>
    {
        [Required(ErrorMessage = "Order id is required.")]
        [DefaultValue("")]
        public Guid OrderId { get; set; }

        [Required(ErrorMessage = "Status is required.")]
        public OrderStatus Status { get; set; }

        [Required(ErrorMessage = "RejectedOrCompletedReason is required.")]
        [StringLength(250, ErrorMessage = "RejectedOrCompletedReason must not exceed 200 characters.")]
        public string RejectedOrCompletedReason { get; set; }
    }
}
