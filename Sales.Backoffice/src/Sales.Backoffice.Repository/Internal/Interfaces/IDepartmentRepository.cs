using Sales.Backoffice.Model;
using Sales.Backoffice.Model.Enums;

namespace Sales.Backoffice.Repository.Internal.Interfaces;

public interface IDepartmentRepository : IUpdateRepository<Department>
{
	Task<Department?> GetByTypeAsync(DepartmentType departmentType);	
}
