using Authentication.Domain.Dtos;
using Authentication.Domain.Entities;
using Authentication.Extensions;
using Authentication.Models;
using Authentication.Services.Interfaces;
using CSharpFunctionalExtensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using PD.Shared.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

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

        public async Task<IResult<AuthToken, DomainError>> GenerateAuthTokenAsync(LoginModel model)
        {
            var result = await _signInManager.PasswordSignInAsync(model.Username, model.Password, false, lockoutOnFailure: false);

            if (!result.Succeeded)
                return Result.Failure<AuthToken, DomainError>(DomainError.BusinessError("Inserted credentials is not correct."));

            var user = await _userManager.FindByNameAsync(model.Username);

            if (user == null)
                return Result.Failure<AuthToken, DomainError>(DomainError.BusinessError("User not found."));

            var roles = await _userManager.GetRolesAsync(user);

            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtExtensions.SecurityKey));
            var signingCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
            var expirationTimeStamp = DateTime.Now.AddMinutes(10);

            var claims = new List<Claim>
            {
                new Claim("name", user.UserName),
                new Claim("role", string.Join(",", roles)),
                new Claim("ss-parcel-ui", user.Id.ToString()),
            };

            var tokenOptions = new JwtSecurityToken(
                claims: claims,
                expires: expirationTimeStamp,
                signingCredentials: signingCredentials
                );

            var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);

            return Result.Success<AuthToken, DomainError>(new AuthToken(tokenString, (int)expirationTimeStamp.Subtract(DateTime.Now).TotalSeconds));
        }

        public async Task<IResult<RegisterUserModel, DomainError>> RegisterUserAndGenerateAuthTokenAsync(RegisterUserDto model)
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
                return Result.Failure<RegisterUserModel, DomainError>(DomainError.BusinessError("Role not found."));
            }

            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "User");

                return Result.Success<RegisterUserModel, DomainError>(new RegisterUserModel() { Username = user.UserName});
            }

            string errorDetail = string.Empty;
            foreach (var error in result.Errors)
            {
                errorDetail += "-" + error.Description + ";";
            }

            return Result.Failure<RegisterUserModel, DomainError>(DomainError.BusinessError(errorDetail));
        }

        public async Task<IResult<RegisterUserModel, DomainError>> RegisterCurierAsync(RegisterCurierDto model)
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
                return Result.Failure<RegisterUserModel, DomainError>(DomainError.BusinessError("Role not found."));
            }

            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                
                await _userManager.AddToRoleAsync(user, "Curier");

                return Result.Success<RegisterUserModel, DomainError>(new RegisterUserModel() { Username = user.UserName });
            }

            string errorDetail = string.Empty;
            foreach (var error in result.Errors)
            {
                errorDetail += "-" + error.Description + ";";
            }

            return Result.Failure<RegisterUserModel, DomainError>(DomainError.BusinessError(errorDetail));
        }
    }
}
