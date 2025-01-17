using Authentication.Domain.Entities;
using Authentication.Persistance.Mappings;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Authentication.Persistance.Context;

public class AuthDbContext: IdentityDbContext<User, Role, Guid, UserClaim, UserRole, UserLogin, RoleClaim, UserToken>
{
    public AuthDbContext(DbContextOptions<AuthDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfiguration(new RoleClaimMap());
        builder.ApplyConfiguration(new RoleMap());
        builder.ApplyConfiguration(new UserClaimMap());
        builder.ApplyConfiguration(new UserLoginMap());
        builder.ApplyConfiguration(new UserMap());
        builder.ApplyConfiguration(new UserRoleMap());
        builder.ApplyConfiguration(new UserTokenMap());
    }
}