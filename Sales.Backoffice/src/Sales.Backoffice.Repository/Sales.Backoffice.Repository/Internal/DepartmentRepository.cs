using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Sales.Backoffice.Model;
using Sales.Backoffice.Model.Enums;
using Sales.Backoffice.Repository.Internal.Interfaces;

namespace Sales.Backoffice.Repository.Internal;

public class DepartmentRepository : IDepartmentRepository
{
    private readonly ApplicationDbContext _context;
    private readonly ILogger<DepartmentRepository> _logger;
    public DepartmentRepository(ApplicationDbContext context, ILogger<DepartmentRepository> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task CreateAsync(Department entity)
    {
        try
        {
            await _context.Departments.AddAsync(entity);
            await _context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, 
                "{RepositoryName} Error while trying to save an entity in Db",
                nameof(DepartmentRepository));

            throw;
        }
    }

    public async Task<IEnumerable<Department>> GetAllAsync()
    {
        return await _context.Departments.ToListAsync();
    }

    public async Task<Department?> GetByIdAsync(Guid id)
    {
       return await _context.Departments.SingleOrDefaultAsync(x => x.Id == id);
    }

    public async Task<Department?> GetByTypeAsync(DepartmentType departmentType)
    {
        return await _context.Departments.SingleOrDefaultAsync(x => x.DepartmentType == departmentType);
    }
}
