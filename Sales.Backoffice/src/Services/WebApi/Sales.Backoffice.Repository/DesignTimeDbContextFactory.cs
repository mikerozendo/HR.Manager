using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Sales.Backoffice.Repository;

public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
{
    public ApplicationDbContext CreateDbContext(string[] args)
    {
        var configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile(Directory.GetCurrentDirectory() + "/../Sales.Backoffice.WebApi/appsettings.Development.json")
            .Build();
        var builder = new DbContextOptionsBuilder<ApplicationDbContext>();
        var connectionString = configuration.GetConnectionString("SqlServer");
        builder.UseSqlServer(connectionString);
        return new ApplicationDbContext(builder.Options);
    }
}