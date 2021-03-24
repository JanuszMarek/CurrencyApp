using BusinessLogic.Module.CryptoApiModule;
using BusinessLogic.Module.CurrencyPriceModule;
using Entity.Entities;
using Microsoft.Azure.WebJobs;
using System.Threading.Tasks;

namespace WebJobs
{
    public class WebJobTimer
    {
        private readonly ICryptoApiService cryptoApiService;
        private readonly ICurrencyPriceService currencyPriceService;

        public WebJobTimer(ICryptoApiService cryptoApiService, ICurrencyPriceService currencyPriceService)
        {
            this.cryptoApiService = cryptoApiService;
            this.currencyPriceService = currencyPriceService;
        }

        //If I scale out, it should still only have one instance running
        [Singleton] 
        public async Task CryptoApiTimer([TimerTrigger("0/1 * * * *")] TimerInfo myTimer)
        {
            var result = await cryptoApiService.GetLatestCryptoPricesAsync();
            await currencyPriceService.AddCurrencyPricesAsync(result);
        }
    }
}
