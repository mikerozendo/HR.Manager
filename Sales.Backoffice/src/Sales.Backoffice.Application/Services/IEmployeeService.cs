using Refit;
using Sales.Backoffice.Dto;
using Sales.Backoffice.Dto.Requests;

namespace Sales.Backoffice.Application.Services;

public interface IEmployeeService
{
    Task<ApiResponse<CreateEmployeeRequest>> PostAsync(CreateEmployeeRequest CreateEmployeeRequest);
    Task<List<GetEmployeesResponse>> GetAsync();
}
