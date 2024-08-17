using Microsoft.EntityFrameworkCore;
using Sales.Backoffice.Model;

namespace Sales.Backoffice.Repository.Mappers;

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
