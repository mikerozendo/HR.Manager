using Microsoft.EntityFrameworkCore;
using Sales.Backoffice.Model;

namespace Sales.Backoffice.Repository.Mappers;

public static class ContactMapper
{
    public static void Map(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Contact>()
        .HasOne(x => x.Agent)
        .WithMany(x => x.Contacts)
        .HasForeignKey(x => x.AgentId)
        .HasPrincipalKey(x => x.Id)
        .OnDelete(DeleteBehavior.Cascade);
    }
}
