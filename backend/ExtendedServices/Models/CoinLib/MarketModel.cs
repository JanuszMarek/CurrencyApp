using Newtonsoft.Json;
using System.Collections.Generic;

namespace ExtendedServices.Models.CoinLib
{
    public class MarketModel
    {
        [JsonProperty("symbol")]
        public string Symbol { get; set; }

        [JsonProperty("volume_24h")]
        public string Volume24h { get; set; }

        [JsonProperty("price")]
        public string Price { get; set; }

        [JsonProperty("exchanges")]
        public IEnumerable<ExchangeModel> Exchanges { get; set; }
    }
}
