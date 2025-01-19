using CSharpFunctionalExtensions;
using MediatR;
using PD.Shared.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Parcel.Application.Features.Orders.Commands.CreateOrder
{
    public class CreateOrderCommand : IRequest<Result<CreateOrderCommand, DomainError>>
    {
        [Required(ErrorMessage = "Title is required.")]
        [StringLength(100, ErrorMessage = "Title must not exceed 100 characters.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Weight is required.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Weight must be greater than zero.")]
        [DefaultValue(0.00)]
        public double Weight { get; set; }

        [Required(ErrorMessage = "Total price is required.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Total price must be greater than zero.")]
        [DefaultValue(0.00)]
        public decimal TotalPrice { get; set; }

        [Required(ErrorMessage = "Destination address is required.")]
        [StringLength(200, ErrorMessage = "Destination address must not exceed 200 characters.")]
        public string DestinationAddress { get; set; }

        [Required(ErrorMessage = "Coortinates is required.")]
        [StringLength(50, ErrorMessage = "Coordinates must not exceed 50 characters.")]
        public string Coortinates { get; set; }

        [Required(ErrorMessage = "Phone number is required.")]
        [StringLength(15, ErrorMessage = "Phone number must not exceed 15 characters.")]
        [RegularExpression("^\\+\\d{1,3}\\d{6,15}$", ErrorMessage = "Phone number is not valid.")]
        [DefaultValue("string")]
        public string PhoneNumber { get; set; }

        [StringLength(500, ErrorMessage = "Order information must not exceed 500 characters.")]
        public string? OrderInfo { get; set; }

        [Required(ErrorMessage = "Status is required.")]
        public int Status { get; set; }
    }
}
