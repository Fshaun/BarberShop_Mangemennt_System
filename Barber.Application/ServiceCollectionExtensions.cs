using Barber.Application.Interfaces;
using Barber.Application.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Caching.Memory;

namespace Barber.Application
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationService(this IServiceCollection collection)
        {
            // Dependency Injection
            collection.AddSingleton<IBarberService, BarberService>();
            collection.AddSingleton<IMemoryCache, MemoryCache>();
            return collection;

        }

    }
}
