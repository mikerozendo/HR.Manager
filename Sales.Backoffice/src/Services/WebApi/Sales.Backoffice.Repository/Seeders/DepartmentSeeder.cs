using Microsoft.Extensions.DependencyInjection;
using Sales.Backoffice.Model;
using Sales.Backoffice.Model.Enums;
using Sales.Backoffice.Repository.Internal.Interfaces;

namespace Sales.Backoffice.Repository.Seeders;

public static class DepartmentSeeder
{
    public static async Task SeedAsync(this IServiceProvider serviceProvider)
    {
        using var context = serviceProvider.GetRequiredService<ApplicationDbContext>();
        var departmentRepository = serviceProvider.GetRequiredService<IDepartmentRepository>();

        var departments = ((IEnumerable<DepartmentType>)Enum.GetValues(typeof(DepartmentType)))
            .ToList()
            .Select(x => new Department
            {
                DepartmentType = x,
                EmployeeBaseSalary = 5000,
                MaxAcceptableEmployees = 50
            })
            .ToList();

        foreach (var department in departments)
        {
            var existsInDb = await departmentRepository.GetByTypeAsync(department.DepartmentType);
            if (existsInDb is null)
                context.Departments.Add(department);
        }

        await context.SaveChangesAsync();
    }
}