using BlogApi.Application.Settings;

namespace BlogApi.Application.Abstraction
{
    public interface ITenantService
    {
        string GetDatabaseProvider();
        string GetConnectionString();
        Tenant GetTenant();
    }
}
