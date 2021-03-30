using BusinessLogic.Module.CryptoApiModule;
using BusinessLogic.Module.CurrencyPriceModule;
using BusinessLogic.Module.CurrencyPriceModule.QueryProvider;
using BusinessLogic.Module.SymbolModule;
using BusinessLogic.Module.SymbolModule.QueryProvider;
using Configuration.Models;
using ExternalServices.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
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
            serviceCollection.AddTransient<ICryptoApiService, CryptoApiService>();

            serviceCollection.AddTransient<ICurrencyPriceService, CurrencyPriceService>();
            serviceCollection.AddTransient<ICurrencyPriceQueryProvider, CurrencyPriceQueryProvider>();

            serviceCollection.AddTransient<ISymbolService, SymbolService>();
            serviceCollection.AddTransient<ISymbolQueryProvider, SymbolQueryProvider>();


            serviceCollection.RegisterServicesAlways();
            serviceCollection.RegisterExternalServices(configuration);
        }

        private static void RegisterServicesAlways(this IServiceCollection serviceCollection)
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
