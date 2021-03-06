using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.IO;

namespace WebJobs
{
    class Program
    {
        private static readonly string EnvironmentName = Environment.GetEnvironmentVariable("ENVIRONMENT");
        private static bool IsDevelopment => EnvironmentName == "Development";
        private static IConfiguration configuration;

        static void Main(string[] args)
        {
            BuildConfiguration();

            var builder = new HostBuilder()
                .ConfigureWebJobs(webJobConfiguration =>
                {
                    webJobConfiguration.AddAzureStorageCoreServices();
                    webJobConfiguration.AddTimers();
                })
                .ConfigureServices(serviceCollection => serviceCollection.AddTransient<SayHelloWebJob>())
                .Build();

            builder.Run();
        }

        private static void BuildConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            if (IsDevelopment)
            {
                builder.AddJsonFile($"appsettings.{EnvironmentName}.json", optional: true, reloadOnChange: true);
            }

            configuration = builder.AddEnvironmentVariables().Build();
        }
    }
}
