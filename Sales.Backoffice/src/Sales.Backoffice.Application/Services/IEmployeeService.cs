using Refit;
using Sales.Backoffice.Dto.Requests;
using Sales.Backoffice.Dto.Responses;

namespace Sales.Backoffice.Application.Services;

public interface IEmployeeService
{
    Task<ApiResponse<EntityCreatedResponse>> PostAsync(CreateEmployeeRequest CreateEmployeeRequest);
    //Task<List<CreateEmployeesResponse>> GetAsync();
}
