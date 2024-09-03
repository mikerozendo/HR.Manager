using Microsoft.EntityFrameworkCore;
using Sales.Backoffice.Model;
using Sales.Backoffice.Model.Enums;
using Sales.Backoffice.Repository.Internal.Interfaces;

namespace Sales.Backoffice.Repository.Internal;

public class DepartmentRepository : IDepartmentRepository
{
	private readonly ApplicationDbContext _context;
	public DepartmentRepository(ApplicationDbContext context)
	{
		_context = context;
	}

	public async Task<Department?> GetByTypeAsync(DepartmentType departmentType)
	{
		return await _context.Departments.SingleOrDefaultAsync(x => x.DepartmentType == departmentType);
	}

	public async Task UpdateAsync(Department entity)
	{
		_context.Departments.Update(entity);
		await _context.SaveChangesAsync();
	}
}
