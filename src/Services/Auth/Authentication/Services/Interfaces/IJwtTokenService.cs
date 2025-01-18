using Authentication.Domain.Dtos;
using Authentication.Models;
using CSharpFunctionalExtensions;
using PD.Shared.Models;

namespace Authentication.Services.Interfaces
{
    public interface IJwtTokenService
    {
        Task<IResult<AuthToken, DomainError>> GenerateAuthTokenAsync(LoginModel model);
        Task<IResult<AuthToken, DomainError>> RegisterUserAndGenerateAuthTokenAsync(RegisterUserDto model);
        Task<IResult<string, DomainError>> RegisterCurierAndGenerateAuthTokenAsync(RegisterCurierDto model);
    }
}
