using Microsoft.Extensions.DependencyInjection;
using System;

namespace Configuration.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void RegisterAutoMapper(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        }
    }
}
