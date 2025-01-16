namespace Authentication.Models
{
    public class AuthToken
    {
        public string Token { get; set; }
        public int ExpirationInSeconds { get; set; }

        public AuthToken(string token, int expirationInSeconds)
        {
            Token = token;
            ExpirationInSeconds = expirationInSeconds;
        }
    }
}
