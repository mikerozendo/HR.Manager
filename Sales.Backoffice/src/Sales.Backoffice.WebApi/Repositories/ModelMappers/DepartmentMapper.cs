using Microsoft.EntityFrameworkCore;
using Sales.Backoffice.WebApi.Models;

namespace Sales.Backoffice.WebApi.Repositories.ModelMappers;

public static class DepartmentMapper
{
    public static void Map(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Department>()
        .HasMany(x => x.Employees)
        .WithOne(x => x.Department)
        .HasForeignKey(x => x.DepartmentId)
        .HasPrincipalKey(x => x.Id);
    }
}
