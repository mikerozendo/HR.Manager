using Microsoft.EntityFrameworkCore;
using Sales.Backoffice.WebApi.Models;

namespace Sales.Backoffice.WebApi.Repositories.ModelMappers;
public static class IndividualPersonMapper
{
    public static void Map(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<IndividualPerson>()
        .UseTptMappingStrategy();
    }
}
