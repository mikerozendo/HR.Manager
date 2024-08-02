using Microsoft.EntityFrameworkCore;
using Sales.Backoffice.WebApi.Models;

namespace Sales.Backoffice.WebApi.Repositories.ModelMappers;

public static class AdressMapper
{
    public static void Map(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Adress>()
        .HasOne(x => x.Agent)
        .WithMany(x => x.Adresses)
        .HasForeignKey(x => x.AgentId)
        .HasPrincipalKey(x => x.Id)
        .OnDelete(DeleteBehavior.Cascade);
    }
}
