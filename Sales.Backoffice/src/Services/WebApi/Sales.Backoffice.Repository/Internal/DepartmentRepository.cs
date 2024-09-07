using Microsoft.EntityFrameworkCore;
using Sales.Backoffice.Model;
using Sales.Backoffice.Model.Enums;
using Sales.Backoffice.Repository.Internal.Interfaces;
using System;
using Microsoft.Extensions.Logging;

namespace Sales.Backoffice.Repository.Internal;

public class DepartmentRepository(ILogger<DepartmentRepository> logger, ApplicationDbContext context) : IDepartmentRepository
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
			logger.LogError(ex, "[{RepositoryName}] Error while trying to save an entity in Db", nameof(DepartmentRepository));
			throw;
		}
	}
}
