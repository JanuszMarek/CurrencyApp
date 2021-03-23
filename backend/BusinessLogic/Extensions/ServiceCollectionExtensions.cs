using BusinessLogic.Module.CryptoApi.QueryProvider;
using BusinessLogic.Module.CryptoCurrency;
using Configuration.Models;
using ExternalServices.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;

namespace BusinessLogic.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void RegisterServicesWebApi(this IServiceCollection serviceCollection)
        {
            serviceCollection.RegisterServicesAlways();
        }

        public static void RegisterServicesWebJobs(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.AddTransient<ICryptoApiQueryProvider, CryptoApiQueryProvider>();
            serviceCollection.AddTransient<ICryptoApiService, CryptoApiService>();

            serviceCollection.RegisterServicesAlways();
            serviceCollection.RegisterExternalServices(configuration);
        }

        private static void RegisterServicesAlways(this IServiceCollection serviceCollection)
        {
            serviceCollection.RegisterAutoMapper();
        }

        private static void RegisterAutoMapper(this IServiceCollection serviceCollection)
        {

        }

        public static void RegisterExternalServices(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.AddHttpClient<IHttpCoinlibService, HttpCoinlibService>(client =>
            {
                var baseUrl = configuration[$"{CoinlibSettings.Name}:{nameof(CoinlibSettings.BaseUrl)}"] ;
                client.BaseAddress = new Uri(baseUrl);
            });
        }
    }
}
