namespace Bragi.DataLayer.Configuration.OptionsModel
{
    public class JwtConfig
    {
        public string SecretKey { get; set; }
        public string ValidIssuer { get; set; }
        public string ValidAudience { get; set; }
        public int ExpirationMinutes { get; set; }
    }
}
