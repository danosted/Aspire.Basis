namespace Aspire.Basis.Constants;
public class AspireServices
{
    public static class Ingress
    {
        public const string Name = "ingress";
    }
    public static class Web
    {
        public const string Name = "web";
        public const string Endpoint = $"https+http://{Name}";
        public const string ProxiedBaseUrl = Endpoint;
        public const string SpaProxyUrl = "https://localhost:3001";
    }

    public static class Api1
    {
        public const string Name = "api1";
        public const string Endpoint = $"https+http://{Name}";
        public const string ProxiedBaseUrl = $"{Endpoint}/{Name}/"; // trailing slash is required due to the extra path segment
    }
}