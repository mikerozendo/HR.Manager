using Microsoft.EntityFrameworkCore;
using Sales.Backoffice.Model;

namespace Sales.Backoffice.Repository.Mappers;

public static class DocumentMapper
{
    public static void Map(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Document>()
            .HasOne(x => x.Agent)
            .WithMany(x => x.Documents)
            .HasForeignKey(x => x.AgentId)
            .HasPrincipalKey(x => x.Id)
            .OnDelete(DeleteBehavior.Cascade);
    }
}