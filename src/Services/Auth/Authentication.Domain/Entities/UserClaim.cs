using Microsoft.AspNetCore.Identity;

namespace Authentication.Domain.Entities;

public class UserClaim: IdentityUserClaim<Guid> { }