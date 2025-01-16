using Authentication.Models;

namespace Authentication.Services.Interfaces
{
    public interface IJwtTokenService
    {
        AuthToken GenerateAuthToken(LoginModel model);
    }
}
