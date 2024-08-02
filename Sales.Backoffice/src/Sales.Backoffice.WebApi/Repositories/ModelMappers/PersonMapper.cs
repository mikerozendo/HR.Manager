using Microsoft.EntityFrameworkCore;
using Sales.Backoffice.WebApi.Models;

namespace Sales.Backoffice.WebApi.Repositories.ModelMappings;

public static class PersonMapper
{
    public static void Map(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Agent>()
        .HasMany(x => x.Documents)
        .WithOne(x => x.Agent)
        .HasPrincipalKey(x => x.Id)
        .OnDelete(DeleteBehavior.Cascade);
    }
}
