using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;

namespace Authentication.Extensions
{
    public static class JwtExtensions
    {
        public const string SecurityKey = "@_parcel_delivery_app_sec_key_2025_@";
        public const string ValidIssuer = "parce_delivery_app_2025_@";
        public const string validAudience = "@_parce_delivery_app_2025_@";

        public static void AddJwtAuthentication(this IServiceCollection services)
        {
            services.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultSignInScheme = IdentityConstants.ApplicationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidIssuer = ValidIssuer,
                    ValidateAudience = true,
                    ValidAudience = validAudience,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(SecurityKey)),
                    RoleClaimType = ClaimTypes.Role
                };
            });
        }
    }
}
