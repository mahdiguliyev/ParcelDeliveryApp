using Authentication.Domain.Entities;
using Authentication.Persistance.Mappings;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Authentication.Persistance.Context;

public class AuthDbContext: IdentityDbContext<User, Role, Guid, UserClaim, UserRole, UserLogin, RoleClaim, UserToken>
{
    public AuthDbContext(DbContextOptions<AuthDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder builder)
    {   
        builder.ApplyConfiguration(new RoleMap());
        builder.ApplyConfiguration(new RoleClaimMap());
        builder.ApplyConfiguration(new UserMap());
        builder.ApplyConfiguration(new UserClaimMap());
        builder.ApplyConfiguration(new UserLoginMap());
        builder.ApplyConfiguration(new UserTokenMap());
        builder.ApplyConfiguration(new UserRoleMap());
    }
}