using AutoMapper;
using Configuration.Models;
using ExternalServices.Models.CoinLib;
using ExternalServices.Services;
using Microsoft.Extensions.Options;
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
        private readonly CoinlibSettings coinlibSettings;
        //private readonly IMapper mapper;

        public CryptoApiService(
            IHttpCoinlibService httpCoinlibService,
            IOptions<CoinlibSettings> options)
            //IMapper mapper)
        {
            this.httpCoinlibService = httpCoinlibService;
            this.coinlibSettings = options.Value;
            //this.mapper = mapper;
        }

        public async Task<IEnumerable<CoinModel>> GetLatestCryptoPricesAsync()
        {
            var response = await httpCoinlibService
                .GetPricesAsync(
                    coinlibSettings.Symbols, 
                    coinlibSettings.PriceCurrency,
                    coinlibSettings.ApiKey);

            return response.Coins;
        }

        public async Task StoreCryptoPricesAsync()
        {

        }
    }
}
