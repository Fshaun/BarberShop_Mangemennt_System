using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Caching.Memory;
using Barber.Infrastructure.Data;

namespace Barber.Infrastructure
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructureService(this IServiceCollection collection)
        {
            // Dependency Injection
            collection.AddDbContext<BarberDbContext>();
            return collection;

        }

    }
}
