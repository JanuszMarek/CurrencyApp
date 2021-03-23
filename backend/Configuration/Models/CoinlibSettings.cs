namespace Configuration.Models
{
    public class CoinlibSettings
    {
        public const string Name = "Coinlib";

        public string BaseUrl { get; set; }
        public string[] Symbols { get; set; }
        public string PriceCurrency { get; set; }
        public string ApiKey { get; set; }
    }
}
