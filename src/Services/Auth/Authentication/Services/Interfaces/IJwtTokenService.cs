using Authentication.Domain.Dtos;
using Authentication.Models;
using CSharpFunctionalExtensions;
using PD.Shared.Models;

namespace Authentication.Services.Interfaces
{
    public interface IJwtTokenService
    {
        Task<IResult<AuthToken, DomainError>> GenerateAuthTokenAsync(LoginModel model);
        Task<IResult<RegisterUserModel, DomainError>> RegisterUserAndGenerateAuthTokenAsync(RegisterUserDto model);
        Task<IResult<RegisterUserModel, DomainError>> RegisterCurierAndGenerateAuthTokenAsync(RegisterCurierDto model);
    }
}
