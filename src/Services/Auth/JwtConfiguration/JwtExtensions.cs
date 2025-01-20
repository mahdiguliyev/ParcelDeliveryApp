using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Authentication.Extensions
{
    public static class JwtExtensions
    {
        public const string JWT_SECURITY_KEY = "uX9tRWR+3aRpXvsxQFw4VbLXhMRf/yHbg+mEX0eqJhQ=";
        public const int JWT_TOKEN_EXPIRY_TIME = 15;
        //public const string ValidIssuer = "parceldeliveryapp2025";
        //public const string ValidAudience = "parceldeliveryapp2025";

        public static void AddJwtAuthentication(this IServiceCollection services)
        {
            services.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JWT_SECURITY_KEY)),
                };
            });
        }
    }
}
