using AutoMapper;
using ExternalServices.Models.CoinLib;
using ExternalServices.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogic.Module.CryptoCurrency
{
    public interface ICryptoApiService
    {
        Task<IEnumerable<CoinModel>> GetLatestCryptoPricesAsync();
    }

    public class CryptoApiService : ICryptoApiService
    {
        private readonly IHttpCoinlibService httpCoinlibService;
        //private readonly IMapper mapper;

        public CryptoApiService(
            IHttpCoinlibService httpCoinlibService)
            //IMapper mapper)
        {
            this.httpCoinlibService = httpCoinlibService;
            //this.mapper = mapper;
        }

        public async Task<IEnumerable<CoinModel>> GetLatestCryptoPricesAsync()
        {
            var cryptoSymbols = new string[] { "BTC, ETH, USDT" };
            var priceCurrency = "PLN";

            var response = await httpCoinlibService.GetPricesAsync(cryptoSymbols, priceCurrency);

            return response.Coins;
        }

        public async Task StoreCryptoPricesAsync()
        {

        }
    }
}
