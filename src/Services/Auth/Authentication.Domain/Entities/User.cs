using Microsoft.AspNetCore.Identity;

namespace Authentication.Domain.Entities;

public class User : IdentityUser<Guid>
{
    public string About { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
}