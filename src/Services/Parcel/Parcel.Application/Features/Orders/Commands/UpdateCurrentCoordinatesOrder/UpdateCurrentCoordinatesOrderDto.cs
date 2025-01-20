namespace Parcel.Application.Features.Orders.Commands.UpdateCurrentCoordinatesOrder
{
    public class UpdateCurrentCoordinatesOrderDto
    {
        public string Title { get; set; }
        public double Weight { get; set; }
        public decimal TotalPrice { get; set; }
        public string DestinationAddress { get; set; }
        public string Coortinates { get; set; }
        public string CurrentCoortinates { get; set; }
        public Guid? CurierId { get; set; }
        public int Status { get; set; }
    }
}
