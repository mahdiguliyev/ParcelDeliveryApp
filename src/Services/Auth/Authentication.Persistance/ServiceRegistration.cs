using Authentication.Domain.Entities;
using Authentication.Persistance.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace Authentication.Persistance;

public static class ServiceRegistration
{
    public static void AddPersistenceServices(this IServiceCollection services)
    {
        services.AddIdentity<User, Role>(options =>
        {
            // User Password Options
            options.Password.RequireDigit = false;
            options.Password.RequiredLength = 5;
            options.Password.RequiredUniqueChars = 0;
            options.Password.RequireNonAlphanumeric = false;
            options.Password.RequireLowercase = false;
            options.Password.RequireUppercase = false;
            // User Username and Email Options
            options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
            options.User.RequireUniqueEmail = true;
        }).AddEntityFrameworkStores<AuthDbContext>();
        services.Configure<SecurityStampValidatorOptions>(options =>
        {
            options.ValidationInterval = TimeSpan.FromSeconds(5); // after assigning new changes (ex: roles), the user is logged out after 15 minutes
        });
    }
}