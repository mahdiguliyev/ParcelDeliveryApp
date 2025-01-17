using Authentication.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Authentication.Persistance.Mappings;

public class UserRoleMap : IEntityTypeConfiguration<UserRole>
{
    public void Configure(EntityTypeBuilder<UserRole> builder)
    {
        builder.HasKey(r => new { r.UserId, r.RoleId });

        builder.ToTable("UserRoles");

        //builder.HasData(
        //    // Category.Create
        //    new UserRole
        //    {
        //        UserId = Guid.NewGuid(),
        //        RoleId = Guid.NewGuid()
        //    },
        //    // Category.Read
        //    new UserRole
        //    {
        //        UserId = Guid.NewGuid(),
        //        RoleId = Guid.NewGuid()
        //    });
    }
}