namespace Parcel.Application.Features.Orders.Queries.GetOrdersListQuery
{
    public class OrdersDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public double Weight { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
