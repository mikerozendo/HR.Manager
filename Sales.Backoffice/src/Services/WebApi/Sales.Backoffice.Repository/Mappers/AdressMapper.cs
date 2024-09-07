using Microsoft.EntityFrameworkCore;
using Sales.Backoffice.Model;

namespace Sales.Backoffice.Repository.Mappers;

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