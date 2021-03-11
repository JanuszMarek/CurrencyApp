using BusinessLogic.Module.CryptoApi.QueryProvider;
using BusinessLogic.Module.CryptoCurrency;
using ExternalServices.Services;
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

        public static void RegisterServicesWebJobs(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<ICryptoApiQueryProvider, CryptoApiQueryProvider>();
            serviceCollection.AddTransient<ICryptoApiService, CryptoApiService>();

            serviceCollection.RegisterServicesAlways();
            serviceCollection.RegisterExternalServices();
        }

        private static void RegisterServicesAlways(this IServiceCollection serviceCollection)
        {
            serviceCollection.RegisterAutoMapper();
        }

        private static void RegisterAutoMapper(this IServiceCollection serviceCollection)
        {

        }

        public static void RegisterExternalServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddHttpClient<IHttpCoinlibService, HttpCoinlibService>(client =>
            {
                //var pmdbBlueSettings = configuration.GetSection("PMDBBlue").Get<PMDBBlueSettings>();
                client.BaseAddress = new Uri("https://coinlib.io/");
            });
        }
    }
}
