using CSharpFunctionalExtensions;
using MediatR;
using PD.Shared.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Parcel.Application.Features.Orders.Commands.AssignOrderToCurier
{
    public class AssignOrderToCurierCommand : IRequest<Result<AssignOrderToCurierDto, DomainError>>
    {
        [Required(ErrorMessage = "Curier id is required.")]
        [DefaultValue("")]
        public Guid CurierId { get; set; }

        [Required(ErrorMessage = "Order id is required.")]
        [DefaultValue("")]
        public Guid OrderId { get; set; }
    }
}
