using Microsoft.AspNetCore.Identity;

namespace Authentication.Domain.Entities;

public class UserToken: IdentityUserToken<Guid> { }