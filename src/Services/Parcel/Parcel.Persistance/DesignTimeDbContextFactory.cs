using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Parcel.Persistance.Context;

namespace Parcel.Persistance
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ParcelContext>
    {
        public ParcelContext CreateDbContext(string[] args)
        {
            DbContextOptionsBuilder<ParcelContext> dbContextOptionsBuilder = new();
            dbContextOptionsBuilder.UseSqlServer(Configuration.ConnectionString);
            return new(dbContextOptionsBuilder.Options);
        }
    }
}
