using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Parcel.Application.Contracts.Persistance;
using Parcel.Persistance.Context;
using Parcel.Persistance.Repositories;

namespace Parcel.Persistance
{
    public static class PersistanceServiceRegistration
    {
        public static IServiceCollection AddInfrastrutureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ParcelContext>(options =>
                    options.UseSqlServer(configuration.GetConnectionString("ParcelConnectionString")));

            services.AddScoped(typeof(IAsyncRepository<>), typeof(AsyncRepository<>));
            services.AddScoped<IOrderRepository, OrderRepository>();

            //services.Configure<EmailSettings>(c => configuration.GetSection("EmailSettings"));
            //services.AddTransient<IEmailService, EmailService>();

            return services;
        }
    }
}
