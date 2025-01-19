using System.IdentityModel.Tokens.Jwt;

namespace Parcel.Application.Helpers
{
    public static class JwtHelper
    {
        public static Guid? GetUserIdFromToken(string token)
        {
            if (string.IsNullOrEmpty(token))
            {
                return null;
            }

            // Remove the 'Bearer ' prefix if it exists
            token = token.Replace("Bearer ", "");

            try
            {
                var handler = new JwtSecurityTokenHandler();
                var jsonToken = handler.ReadToken(token) as JwtSecurityToken;

                // Replace "sub" with the actual claim type used in your token for UserId
                var userIdClaim = jsonToken?.Claims.FirstOrDefault(c => c.Type == "ss-parcel-ui");

                if (userIdClaim == null)
                {
                    return null;
                }

                if (Guid.TryParse(userIdClaim.Value, out var userId))
                {
                    return userId;
                }
            }
            catch (Exception ex)
            {
                // Optionally log the exception or handle it as necessary
                throw new UnauthorizedAccessException("Invalid token.", ex);
            }

            return null;
        }
    }
}
