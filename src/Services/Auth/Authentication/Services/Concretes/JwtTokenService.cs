using Authentication.Extensions;
using Authentication.Services.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Authentication.Models;
using Authentication.Domain.Entities;
using Authentication.Domain.Dtos;
using System.Data;

namespace Authentication.Services.Concretes
{
    public class JwtTokenService : IJwtTokenService
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly RoleManager<Role> _roleManager;

        public JwtTokenService(UserManager<User> userManager, SignInManager<User> signInManager, RoleManager<Role> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        public async Task<AuthToken> GenerateAuthTokenAsync(LoginModel model)
        {
            var result = await _signInManager.PasswordSignInAsync(model.Username, model.Password, false, lockoutOnFailure: false);

            if (!result.Succeeded)
                return new AuthToken(string.Empty, 0);

            var user = await _userManager.FindByNameAsync(model.Username);

            if (user == null)
                return new AuthToken(string.Empty, 0);

            var roles = await _userManager.GetRolesAsync(user);

            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtExtensions.SecurityKey));
            var signingCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
            var expirationTimeStamp = DateTime.Now.AddMinutes(10);

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Name, user.UserName),
                new Claim("Role", string.Join(",", roles)),
            };

            var tokenOptions = new JwtSecurityToken(
                issuer: JwtExtensions.ValidIssuer,
                claims: claims,
                expires: expirationTimeStamp,
                signingCredentials: signingCredentials
                );

            var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);

            return new AuthToken(tokenString, (int)expirationTimeStamp.Subtract(DateTime.Now).TotalSeconds);
        }

        public async Task<AuthToken> RegisterUserAndGenerateAuthTokenAsync(RegisterUserDto model)
        {
            var user = new User
            {
                UserName = model.Email,
                Email = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName,
                About = model.About,
                PhoneNumber = model.Phone,
            };

            var roleExists = await _roleManager.RoleExistsAsync("User");
            if (!roleExists)
            {
                return new AuthToken(string.Empty, 0);
            }

            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "User");

                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtExtensions.SecurityKey));
                var signingCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
                var expirationTimeStamp = DateTime.Now.AddMinutes(10);

                var claims = new List<Claim>
                {
                    new Claim(JwtRegisteredClaimNames.Name, user.UserName),
                    new Claim("Role", "User"),
                };

                var tokenOptions = new JwtSecurityToken(
                    issuer: JwtExtensions.ValidIssuer,
                    claims: claims,
                    expires: expirationTimeStamp,
                    signingCredentials: signingCredentials
                    );

                var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);

                return new AuthToken(tokenString, (int)expirationTimeStamp.Subtract(DateTime.Now).TotalSeconds);
            }

            foreach (var error in result.Errors)
            {
                //ModelState.AddModelError(string.Empty, error.Description);
            }

            return new AuthToken(string.Empty, 0);
        }

        public async Task<bool> RegisterCurierAndGenerateAuthTokenAsync(RegisterCurierDto model)
        {
            var user = new User
            {
                UserName = model.Email,
                Email = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName,
                About = model.About,
                PhoneNumber = model.Phone,
            };

            var roleExists = await _roleManager.RoleExistsAsync("Curier");
            if (!roleExists)
            {
                return false;
            }

            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                
                await _userManager.AddToRoleAsync(user, "Curier");

                return true;
            }

            foreach (var error in result.Errors)
            {
                //ModelState.AddModelError(string.Empty, error.Description);
            }

            return false;
        }
    }
}
