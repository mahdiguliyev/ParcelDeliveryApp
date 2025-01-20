using CSharpFunctionalExtensions;
using MediatR;
using PD.Shared.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Parcel.Application.Features.Orders.Queries.TrakOrderQuery
{
    public class TrakOrderQuery : IRequest<Result<TrackOrderDto, DomainError>>
    {
        [Required(ErrorMessage = "Order id is required.")]
        [DefaultValue("")]
        public Guid OrderId { get; set; }
    }
}
