using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using CSharpFunctionalExtensions;
using MediatR;
using PD.Shared.Models;

namespace Parcel.Application.Features.Orders.Commands.UpdateCurrentCoordinatesOrder
{
    public class UpdateCurrentCoordinatesOrderCommand : IRequest<Result<UpdateCurrentCoordinatesOrderDto, DomainError>>
    {
        [Required(ErrorMessage = "Order id is required.")]
        [DefaultValue("")]
        public Guid OrderId { get; set; }

        [Required(ErrorMessage = "Coortinates is required.")]
        [StringLength(50, ErrorMessage = "Coordinates must not exceed 50 characters.")]
        public string CurrentCoortinates { get; set; }
    }
}
