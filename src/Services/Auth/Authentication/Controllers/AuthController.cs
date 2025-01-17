using Authentication.Models;
using Authentication.Services.Interfaces;
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

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            var loginResult = await _jwtTokenService.GenerateAuthToken(model);

            return string.IsNullOrEmpty(loginResult.Token) ? Unauthorized() : Ok(loginResult);
        }
    }
}
