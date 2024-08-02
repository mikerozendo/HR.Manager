using Refit;
using Sales.Backoffice.Application.RequestModels;

namespace Sales.Backoffice.Application.Services;

public interface IEmployeeService
{
    Task<ApiResponse<EmployeeRequest>> PostAsync(EmployeeRequest EmployeeRequest);
    Task<ApiResponse<List<EmployeeRequest>>> GetAsync();
}
