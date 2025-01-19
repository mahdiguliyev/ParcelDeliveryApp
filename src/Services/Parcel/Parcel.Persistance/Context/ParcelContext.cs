using Microsoft.EntityFrameworkCore;
using Parcel.Domain.Common;
using Parcel.Domain.Entities;
using Parcel.Persistance.Mappings;

namespace Parcel.Persistance.Context
{
    public class ParcelContext : DbContext
    {
        public ParcelContext(DbContextOptions<ParcelContext> options) : base(options) { }

        public DbSet<Order> Orders { get; set; }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var datas = ChangeTracker.Entries<EntityBase>();

            foreach (var data in datas)
            {
                _ = data.State switch
                {
                    EntityState.Added => data.Entity.CreatedDate = DateTime.UtcNow,
                    EntityState.Modified => data.Entity.ModifiedDate = DateTime.UtcNow,
                    _ => DateTime.UtcNow
                };
            }

            return await base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new OrderMap());
        }
    }
}
