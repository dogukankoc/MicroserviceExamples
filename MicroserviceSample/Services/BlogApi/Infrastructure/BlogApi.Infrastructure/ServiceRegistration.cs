using BlogApi.Application.Abstraction;
using BlogApi.Infrastructure.Concrete;
using Microsoft.Extensions.DependencyInjection;

namespace BlogApi.Infrastructure
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructureService(this IServiceCollection collection)
        {
            collection.AddTransient<ITenantService, TenantService>();
        }
    }
}
