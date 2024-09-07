using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Sales.Backoffice.Model;
using Sales.Backoffice.Model.Enums;
using Sales.Backoffice.Repository.Internal.Interfaces;

namespace Sales.Backoffice.Repository.Internal;

public class EmployeeRepository(ILogger<Employee> logger, ApplicationDbContext dbContext) : IEmployeeRepository
{
    public async Task CreateAsync(Employee entity)
    {
        try
        {
            await dbContext.Employees.AddAsync(entity);
            await dbContext.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "[{RepositoryName}] Error while trying to save an entity in Db",
                nameof(EmployeeRepository));
            throw;
        }
    }

    public async Task<List<Employee>> GetByDepartmentAsync(DepartmentType departmentType)
    {
        return await dbContext.Employees
            .Where(x => x.Department.DepartmentType == departmentType)
            .ToListAsync();
    }

    public async Task<Employee?> GetByIdAsync(Guid id)
    {
        return await dbContext.Employees
            .Include(x => x.Department)
            .SingleOrDefaultAsync(x => x.Id == id);
    }
}