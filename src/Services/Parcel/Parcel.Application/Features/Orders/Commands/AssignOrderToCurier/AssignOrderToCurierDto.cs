namespace Parcel.Application.Features.Orders.Commands.AssignOrderToCurier
{
    public class AssignOrderToCurierDto
    {
        public string Title { get; set; }
        public double Weight { get; set; }
        public decimal TotalPrice { get; set; }
        public Guid CurierId { get; set; }
        public int Status { get; set; }
    }
}
