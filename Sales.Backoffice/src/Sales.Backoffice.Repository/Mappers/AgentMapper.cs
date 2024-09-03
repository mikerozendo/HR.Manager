using Microsoft.EntityFrameworkCore;
using Sales.Backoffice.Model;

namespace Sales.Backoffice.Repository.Mappers;

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
