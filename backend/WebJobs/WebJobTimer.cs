using BusinessLogic.Module.CryptoApiModule;
using Microsoft.Azure.WebJobs;
using System.Threading.Tasks;

namespace WebJobs
{
    public class WebJobTimer
    {
        private readonly ICryptoApiService cryptoApiService;

        public WebJobTimer(ICryptoApiService cryptoApiService)
        {
            this.cryptoApiService = cryptoApiService;
        }

        //If I scale out, it should still only have one instance running
        [Singleton] 
        public async Task CryptoApiTimer([TimerTrigger("0/1 * * * *")] TimerInfo myTimer)
        {
            var result = await cryptoApiService.GetLatestCryptoPricesAsync();
        }
    }
}
