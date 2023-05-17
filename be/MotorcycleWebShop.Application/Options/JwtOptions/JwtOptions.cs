namespace MotorcycleWebShop.Application.Options.JwtOptions
{
    public class JwtOptions
    {
        public string ValidIssuer { get; init; }
        public string ValidAudience { get; init; }
        public bool ValidateIssuer { get; init; }
        public bool ValidateAudience { get; init; }
        public string SecurityKey { get; init; }
        public bool ValidateIssuerSigningKey { get; init; }
        public bool ValidateLifetime { get; init; }
    }
}
