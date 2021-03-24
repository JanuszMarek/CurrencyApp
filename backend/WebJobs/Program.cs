using Configuration.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.Threading.Tasks;
using WebJobs.Extensions;

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
                builder.AddJsonFile($"appsettings.{CurrentEnvironment}.json", optional: true, reloadOnChange: true);
                builder.AddUserSecrets<Program>();
            }

            var configuration = builder.Build();

            string keyVaultEndpoint = configuration["KeyVault:Endpoint"];
            if (!string.IsNullOrWhiteSpace(keyVaultEndpoint))
            {
                builder.AddAzureKeyVault(keyVaultEndpoint);
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
                .ConfigureServices(serviceCollection => 
                {
                    serviceCollection.RegisterServices(configuration);
                    serviceCollection.RegisterAutoMapper();
                })
                .UseConsoleLifetime();

            return builder.Build();
        }
    }
}
