using Authentication.Domain.Dtos;
using Authentication.Models;
using Authentication.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PD.Shared.Models;

namespace Authentication.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IJwtTokenService _jwtTokenService;
        

        public AuthController(IJwtTokenService jwtTokenService)
        {
            _jwtTokenService = jwtTokenService;
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            var loginResult = await _jwtTokenService.GenerateAuthTokenAsync(model);

            return loginResult.IsSuccess ?
                Ok(ApiResponse<AuthToken>.Success(loginResult.Value)) :
                BadRequest(ApiResponse<string>.Failure(loginResult.Error.ErrorMessage));
        }

        [HttpPost("registeruser")]
        [AllowAnonymous]
        public async Task<IActionResult> RegisterUser([FromBody] RegisterUserDto model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var registerResult = await _jwtTokenService.RegisterUserAndGenerateAuthTokenAsync(model);


            return registerResult.IsSuccess ?
                Ok(ApiResponse<RegisterUserModel>.Success(registerResult.Value)) :
                BadRequest(ApiResponse<RegisterUserModel>.Failure(registerResult.Error.ErrorMessage));
        }

        [HttpPost("registercurier")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> RegisterCurier([FromBody] RegisterCurierDto model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var registerResult = await _jwtTokenService.RegisterCurierAsync(model);

            return registerResult.IsSuccess ?
                Ok(ApiResponse<RegisterUserModel>.Success(registerResult.Value)) :
                BadRequest(ApiResponse<RegisterUserModel>.Failure(registerResult.Error.ErrorMessage));
        }
    }
}
