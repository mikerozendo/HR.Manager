using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Sales.Backoffice.Model;
using Sales.Backoffice.Model.Enums;
using Sales.Backoffice.Repository.Internal.Interfaces;

namespace Sales.Backoffice.Repository.Seeders;

public static class DepartmentSeeder
{
    public static void Seed(this IServiceProvider serviceProvider)
    {
        using var scope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope();
        using var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
        var departmentRepository = scope.ServiceProvider.GetRequiredService<IDepartmentRepository>();

        context.Database.Migrate();

        var departments = ((IEnumerable<DepartmentType>)Enum.GetValues(typeof(DepartmentType)))
            .ToList()
            .Select(x => new Department { DepartmentType = x, EmployeeBaseSalary = 5000, MaxAcceptableEmployees = 5 })
            .ToList();

        foreach (var department in departments)
        {
            var existsInDb = departmentRepository.GetByTypeAsync(department.DepartmentType).Result;
            if (existsInDb is null)
                context.Departments.Add(department);
        }

        context.SaveChanges();
    }
}