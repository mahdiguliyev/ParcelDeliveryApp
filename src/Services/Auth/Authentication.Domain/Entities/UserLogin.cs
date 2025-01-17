using Microsoft.AspNetCore.Identity;

namespace Authentication.Domain.Entities;

public class UserLogin: IdentityUserLogin<Guid> { }