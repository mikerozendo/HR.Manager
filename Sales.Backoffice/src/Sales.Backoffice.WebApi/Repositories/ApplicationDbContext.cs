using Microsoft.EntityFrameworkCore;

namespace Sales.Backoffice.WebApi.Repositories;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        optionsBuilder.UseLazyLoadingProxies(false);
        optionsBuilder.UseChangeTrackingProxies(false, false);
        optionsBuilder.EnableThreadSafetyChecks(false);
        //optionsBuilder.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}
