using ExtendedServices.Models.CoinLib;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Threading.Tasks;

namespace ExtendedServices.Services
{
    public interface IHttpCoinlibService
    {
        Task<CoinModel> GetCoinsAsync(IEnumerable<string> cryptoSymbols, string priceCurrency);
    }

    public class HttpCoinlibService : HttpBasicService, IHttpCoinlibService
    {
        public HttpCoinlibService(HttpClient httpClient) : base(httpClient)
        {
        }

        public async Task<CoinModel> GetCoinsAsync(IEnumerable<string> cryptoSymbols, string priceCurrency)
        {
            var parameters = new Dictionary<string, string>
            {
                ["symbol"] = string.Join(",", cryptoSymbols),
                ["pref"] = priceCurrency
            };

            var query = new FormDataCollection(parameters).ReadAsNameValueCollection().ToString();
            var response = await GetAsync<CoinModel>(query);

            return response;
        }
    }
}
