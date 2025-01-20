﻿namespace Parcel.Application.Features.Orders.Queries.GetOrdersListQuery
{
    public class OrdersDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public double Weight { get; set; }
        public decimal TotalPrice { get; set; }
        public string DestinationAddress { get; set; }
        public string Coortinates { get; set; }
        public string PhoneNumber { get; set; }
        public string? OrderInfo { get; set; }
        public Guid UserId { get; set; }
        public Guid? CurierId { get; set; }
        public int Status { get; set; }
    }
}
