using BusinessLogic.Extensions;
using Configuration.Models;
using Entity.Constants;
using Entity.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace WebJobs.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void RegisterServices(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.AddTransient<WebJobTimer>();
            serviceCollection.AddDbContext<CurrencyContext>(option =>
                option.UseSqlServer(configuration[ConfigurationStrings.ConnectionString])
            );
            serviceCollection.RegisterServicesWebJobs(configuration);

            serviceCollection.Configure<CoinlibSettings>(options =>
                configuration.GetSection(CoinlibSettings.Name).Bind(options));
        }
    }
}
