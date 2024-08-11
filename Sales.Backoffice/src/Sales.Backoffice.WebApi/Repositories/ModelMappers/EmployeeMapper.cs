using Microsoft.EntityFrameworkCore;
using Sales.Backoffice.WebApi.Models;

namespace Sales.Backoffice.WebApi.Repositories.ModelMappers;

public static class EmployeeMapper
{
    public static void Map(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employee>()
        .UseTptMappingStrategy();

        modelBuilder.Entity<Employee>()
        .HasOne(x => x.Department)
        .WithMany(x => x.Employees)
        .HasForeignKey(x => x.DepartmentId)
        .HasPrincipalKey(x => x.Id);
    }
}
