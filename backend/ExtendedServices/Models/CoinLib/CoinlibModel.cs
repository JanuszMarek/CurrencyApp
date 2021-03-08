using ExtendedServices.Models.CoinLib;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace ExtendedServices.Models.CoinLiub
{
    public class CoinlibModel
    {
        [JsonProperty("coins")]
        public IEnumerable<CoinModel> Coins { get; set; }

        [JsonProperty("remaining")]
        public int Remaining { get; set; }
    }
}
