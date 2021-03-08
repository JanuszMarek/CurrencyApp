using Newtonsoft.Json;

namespace ExtendedServices.Models.CoinLib
{
    public class ExchangeModel
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("volume_24h")]
        public string Volume24h { get; set; }

        [JsonProperty("price")]
        public string Price { get; set; }
    }
}
