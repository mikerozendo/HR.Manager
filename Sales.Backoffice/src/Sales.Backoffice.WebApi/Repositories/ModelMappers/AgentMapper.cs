using Microsoft.EntityFrameworkCore;
using Sales.Backoffice.WebApi.Models;

namespace Sales.Backoffice.WebApi.Repositories.ModelMappers;

public static class AgentMapper
{
    public static void Map(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Agent>()
        .HasMany(x => x.Contacts)
        .WithOne(x => x.Agent)
        .HasForeignKey(x => x.AgentId)
        .HasPrincipalKey(x => x.Id)
        .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Agent>()
        .HasMany(x => x.Adresses)
        .WithOne(x => x.Agent)
        .HasForeignKey(x => x.AgentId)
        .HasPrincipalKey(x => x.Id)
        .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Agent>()
        .HasMany(x => x.Documents)
        .WithOne(x => x.Agent)
        .HasForeignKey(x => x.AgentId)
        .HasPrincipalKey(x => x.Id)
        .OnDelete(DeleteBehavior.Cascade);
    }
}
