using Authentication.Domain.Dtos;
using Authentication.Models;
using Authentication.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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

            return string.IsNullOrEmpty(loginResult.Token) ? Unauthorized() : Ok(loginResult);
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

            return string.IsNullOrEmpty(registerResult.Token) ? Unauthorized() : Ok(registerResult);
        }

        [HttpPost("registercurier")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> RegisterCurier([FromBody] RegisterCurierDto model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var registerResult = await _jwtTokenService.RegisterCurierAndGenerateAuthTokenAsync(model);

            return registerResult ? Ok(registerResult) : BadRequest();
        }
    }
}
