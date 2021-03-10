using Newtonsoft.Json;
using System.Collections.Generic;

namespace ExternalServices.Models.CoinLib
{
    public class CoinlibModel
    {
        [JsonProperty("coins")]
        public IEnumerable<CoinModel> Coins { get; set; }

        [JsonProperty("remaining")]
        public int Remaining { get; set; }
    }
}
