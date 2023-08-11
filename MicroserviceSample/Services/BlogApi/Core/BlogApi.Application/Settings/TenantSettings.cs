namespace BlogApi.Application.Settings
{
    public class TenantSettings
    {
        public DefaultSetting Defaults { get; set; }
        public List<Tenant> Tenants { get; set; }
    }
}
