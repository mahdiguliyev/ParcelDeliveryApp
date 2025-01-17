using Authentication.Models;

namespace Authentication.Services.Interfaces
{
    public interface IJwtTokenService
    {
        Task<AuthToken> GenerateAuthToken(LoginModel model);
    }
}
