using Authentication.Extensions;
using Authentication.Models;
using Authentication.Services.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Authentication.Services.Concretes
{
    public class JwtTokenService : IJwtTokenService
    {
        private readonly List<User> _users = new()
        {
            new() {Username = "admin", Password = "admin123", Role = "ADMIN", Scopes = new[] {"create.curier"}},
            new() {Username = "user", Password = "user123", Role = "USER", Scopes = new[] {"list.parcels"}},
            new() {Username = "curier", Password = "curier123", Role = "CURIER", Scopes = new[] {"list.parcels"}},
        };

        public AuthToken GenerateAuthToken(LoginModel model)
        {
            var user = _users.FirstOrDefault(u => u.Username == model.Username && u.Password == model.Password);

            if (user == null)
                return new AuthToken(string.Empty, 0);

            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtExtensions.SecurityKey));
            var signingCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
            var expirationTimeStamp = DateTime.Now.AddMinutes(10);

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Name, user.Username),
                new Claim("Role", user.Role),
                new Claim("Scope", string.Join("-", user.Scopes)),
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
    }
}
