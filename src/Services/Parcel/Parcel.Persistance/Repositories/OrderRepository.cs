using Microsoft.EntityFrameworkCore;
using Parcel.Application.Contracts.Persistance;
using Parcel.Domain.Entities;
using Parcel.Persistance.Context;

namespace Parcel.Persistance.Repositories
{
    public class OrderRepository : AsyncRepository<Order>, IOrderRepository
    {
        public OrderRepository(ParcelContext context) : base(context) { }

        public async Task<IEnumerable<Order>> GetOrdersByUserNameAsync(Guid userId)
        {
            var orderList = await _context.Orders
                .Where(o => o.UserId == userId)
                .ToListAsync();
            return orderList;
        }
    }
}
