using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Sales.Backoffice.Model;
using Sales.Backoffice.Model.Enums;
using Sales.Backoffice.Repository.Internal.Interfaces;

namespace Sales.Backoffice.Repository.Internal;

public class EmployeeRepository : IEmployeeRepository
{
	private readonly ILogger<Employee> _logger;
	private readonly ApplicationDbContext _dbContext;
	public EmployeeRepository(ILogger<Employee> logger, ApplicationDbContext dbContext)
	{
		_logger = logger;
		_dbContext = dbContext;
	}

	public async Task CreateAsync(Employee entity)
	{
		try
		{
			await _dbContext.Employees.AddAsync(entity);
			await _dbContext.SaveChangesAsync();
		}
		catch (Exception ex)
		{
			_logger.LogError(ex,
				"{RepositoryName} Error while trying to save an entity in Db",
				nameof(EmployeeRepository));

			throw;
		}
	}

	public async Task<List<Employee>> GetByDepartmentAsync(DepartmentType departmentType)
	{
		return await _dbContext.Employees
				 .Where(x => x.Department.DepartmentType == departmentType)
				 .ToListAsync();
	}

	public async Task<Employee?> GetByIdAsync(Guid id)
	{	
		return await _dbContext.Employees
		.Include(x => x.Department)
		.SingleOrDefaultAsync(x => x.Id == id);
	}
}
