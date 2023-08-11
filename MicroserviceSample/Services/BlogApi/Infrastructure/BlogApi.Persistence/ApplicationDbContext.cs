using BlogApi.Application.Abstraction;
using BlogApi.Domain.Contracts;
using BlogApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext : DbContext
{
    readonly ITenantService _tenantService;
    string tenantId;
    public ApplicationDbContext(DbContextOptions options, ITenantService tenantService) : base(options)
    {
        _tenantService = tenantService;
        tenantId = _tenantService.GetTenant()?.TenantId;
    }
    public DbSet<Blog> Blogs { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Blog>().HasQueryFilter(p => p.TenantId == tenantId);
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var tenantConnectionString = _tenantService.GetConnectionString();
        if (!string.IsNullOrEmpty(tenantConnectionString))
        {
            var dbProvider = _tenantService.GetDatabaseProvider();
            if (dbProvider.ToLower() == "mssql")
                optionsBuilder.UseSqlServer(tenantConnectionString);
        }
    }
    public async override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        foreach (var entry in ChangeTracker.Entries<IMustHaveTenant>().ToList())
        {
            switch (entry.State)
            {
                case EntityState.Added:
                case EntityState.Modified:
                    entry.Entity.TenantId = tenantId;
                    break;
            }
        }

        return await base.SaveChangesAsync(cancellationToken);
    }
}
