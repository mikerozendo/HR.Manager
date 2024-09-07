using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Sales.Backoffice.Model;
using Sales.Backoffice.Model.Enums;
using Sales.Backoffice.Repository.Internal.Interfaces;

namespace Sales.Backoffice.Repository.Internal;

public class DepartmentRepository(ILogger<DepartmentRepository> logger, ApplicationDbContext context)
    : IDepartmentRepository
{
    public async Task<Department?> GetByTypeAsync(DepartmentType departmentType)
    {
        return await context.Departments.SingleOrDefaultAsync(x => x.DepartmentType == departmentType);
    }

    public async Task UpdateAsync(Department entity)
    {
        try
        {
            context.Departments.Update(entity);
            await context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "[{RepositoryName}] Error while trying to save an entity in Db",
                nameof(DepartmentRepository));
            throw;
        }
    }
}