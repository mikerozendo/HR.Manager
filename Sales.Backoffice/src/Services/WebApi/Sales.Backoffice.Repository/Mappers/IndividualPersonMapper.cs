using Microsoft.EntityFrameworkCore;
using Sales.Backoffice.Model;

namespace Sales.Backoffice.Repository.Mappers;

public static class IndividualPersonMapper
{
    public static void Map(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<IndividualPerson>()
            .UseTptMappingStrategy();
    }
}