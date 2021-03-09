using CurrencyApi.EF.Constants;
using EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.Threading.Tasks;

namespace WebJobs
{
    class Program
    {
        private static readonly string CurrentEnvironment = Environment.GetEnvironmentVariable("ENVIRONMENT");
        private static bool IsDevelopment => CurrentEnvironment == EnvironmentName.Development;
        private static IConfiguration configuration;

        static async Task Main()
        {
            configuration = BuildConfiguration();
            var host = BuildHost();

            using (host)
            {
                await host.RunAsync();
            }
        }

        private static IConfigurationRoot BuildConfiguration()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory());
            builder.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            if (IsDevelopment)
            {
                builder.AddJsonFile($"appsettings.{CurrentEnvironment}.json", optional: true);
            }

            return builder.AddEnvironmentVariables().Build();
        }

        private static IHost BuildHost()
        {
            var builder = new HostBuilder();

            if (IsDevelopment)
            {
                builder.UseEnvironment(EnvironmentName.Development);
            }

            builder.ConfigureWebJobs(webJobConfiguration =>
                    {
                        webJobConfiguration
                            .AddAzureStorageCoreServices()
                            .AddTimers();
                    })
                .ConfigureLogging((context, b) =>
                {
                    b.AddConsole();
                })
                .ConfigureServices(serviceCollection => ConfigureService(serviceCollection))
                .UseConsoleLifetime();

            return builder.Build();
        }

        private static void ConfigureService(IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<WebJobTimer>();
            serviceCollection.AddDbContext<CurrencyContext>(option =>
                option.UseSqlServer(configuration[ConfigurationStrings.ConnectionString])
            );
        }
    }
}
