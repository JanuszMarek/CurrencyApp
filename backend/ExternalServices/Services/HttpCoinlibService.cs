using ExternalServices.Builder;
using ExternalServices.Models.CoinLib;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Threading.Tasks;

namespace ExternalServices.Services
{
    public interface IHttpCoinlibService
    {
        Task<CoinlibModel> GetPricesAsync(IEnumerable<string> cryptoSymbols, string priceCurrency, string apiKey);
    }

    public class HttpCoinlibService : HttpBasicService, IHttpCoinlibService
    {
        public HttpCoinlibService(HttpClient httpClient) : base(httpClient)
        {
            apiRoute = "/api/v1/";
        }

        public async Task<CoinlibModel> GetPricesAsync(IEnumerable<string> cryptoSymbols, string priceCurrency, string apiKey)
        {
            var endpoint = "coin";
            var parametersDict = new Dictionary<string, string>
            {
                ["symbol"] = string.Join(",", cryptoSymbols),
                ["pref"] = priceCurrency,
                ["key"] = apiKey
            };

            var response = await GetAsync<CoinlibModel>(endpoint, parametersDict);

            return response;
        }
    }
}
