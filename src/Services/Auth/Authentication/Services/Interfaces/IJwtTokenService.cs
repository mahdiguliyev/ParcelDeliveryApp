using Authentication.Domain.Dtos;
using Authentication.Models;

namespace Authentication.Services.Interfaces
{
    public interface IJwtTokenService
    {
        Task<AuthToken> GenerateAuthTokenAsync(LoginModel model);
        Task<AuthToken> RegisterUserAndGenerateAuthTokenAsync(RegisterUserDto model);
        Task<bool> RegisterCurierAndGenerateAuthTokenAsync(RegisterCurierDto model);
    }
}
