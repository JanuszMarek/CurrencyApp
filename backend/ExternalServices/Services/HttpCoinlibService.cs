using ExternalServices.Models.CoinLib;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Threading.Tasks;

namespace ExternalServices.Services
{
    public interface IHttpCoinlibService
    {
        Task<CoinlibModel> GetPricesAsync(IEnumerable<string> cryptoSymbols, string priceCurrency);
    }

    public class HttpCoinlibService : HttpBasicService, IHttpCoinlibService
    {
        public HttpCoinlibService(HttpClient httpClient) : base(httpClient)
        {
        }

        public async Task<CoinlibModel> GetPricesAsync(IEnumerable<string> cryptoSymbols, string priceCurrency)
        {
            var parameters = new Dictionary<string, string>
            {
                ["symbol"] = string.Join(",", cryptoSymbols),
                ["pref"] = priceCurrency
            };

            var query = new FormDataCollection(parameters).ReadAsNameValueCollection().ToString();
            var response = await GetAsync<CoinlibModel>(query);

            return response;
        }
    }
}
