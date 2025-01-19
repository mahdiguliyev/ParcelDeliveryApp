using Parcel.Domain.Entities;

namespace Parcel.Application.Contracts.Persistance
{
    public interface IOrderRepository : IAsyncRepository<Order>
    {
        Task<IEnumerable<Order>> GetOrdersByUserNameAsync(Guid userId);
    }
}
