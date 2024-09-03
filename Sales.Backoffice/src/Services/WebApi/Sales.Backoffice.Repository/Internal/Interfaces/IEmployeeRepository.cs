using Sales.Backoffice.Model;
using Sales.Backoffice.Model.Enums;

namespace Sales.Backoffice.Repository.Internal.Interfaces;

public interface IEmployeeRepository : 
    ICreateRepository<Employee>, 
    IGetByIdRepository<Employee>
{
    Task<List<Employee>> GetByDepartmentAsync(DepartmentType departmentType);
}
