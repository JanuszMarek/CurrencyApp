using Newtonsoft.Json;
using System.Collections.Generic;

namespace CurrencyApi
{
    public class Exchanx
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("volume_24h")]
        public string Volume24h { get; set; }

        [JsonProperty("price")]
        public string Price { get; set; }
    }

    public class Market
    {
        [JsonProperty("symbol")]
        public string Symbol { get; set; }

        [JsonProperty("volume_24h")]
        public string Volume24h { get; set; }

        [JsonProperty("price")]
        public string Price { get; set; }

        [JsonProperty("exchanges")]
        public IEnumerable<Exchanx> Exchanges { get; set; }
    }

    public class Coin
    {
        [JsonProperty("symbol")]
        public string Symbol { get; set; }

        [JsonProperty("show_symbol")]
        public string ShowSymbol { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("rank")]
        public int Rank { get; set; }

        [JsonProperty("price")]
        public string Price { get; set; }

        [JsonProperty("market_cap")]
        public string MarketCap { get; set; }

        [JsonProperty("total_volume_24h")]
        public string TotalVolume24h { get; set; }

        [JsonProperty("low_24h")]
        public string Low24h { get; set; }

        [JsonProperty("high_24h")]
        public string High24h { get; set; }

        [JsonProperty("delta_1h")]
        public string Delta1h { get; set; }

        [JsonProperty("delta_24h")]
        public string Delta24h { get; set; }

        [JsonProperty("delta_7d")]
        public string Delta7d { get; set; }

        [JsonProperty("delta_30d")]
        public string Delta30d { get; set; }

        [JsonProperty("markets")]
        public IEnumerable<Market> Markets { get; set; }

        [JsonProperty("last_updated_timestamp")]
        public int LastUpdatedTimestamp { get; set; }
    }

    public class CoinlibModel
    {
        [JsonProperty("coins")]
        public IEnumerable<Coin> Coins { get; set; }

        [JsonProperty("remaining")]
        public int Remaining { get; set; }
    }
}
