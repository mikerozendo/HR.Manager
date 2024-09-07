using Microsoft.EntityFrameworkCore;
using Sales.Backoffice.Model;

namespace Sales.Backoffice.Repository.Mappers;

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