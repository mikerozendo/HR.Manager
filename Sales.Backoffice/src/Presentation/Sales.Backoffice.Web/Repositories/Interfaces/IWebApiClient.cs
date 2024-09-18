using Refit;
using Sales.Backoffice.Dto.Enums;
using Sales.Backoffice.Dto.Requests.Commands;
using Sales.Backoffice.Dto.Responses;

namespace Sales.Backoffice.Web.Repositories.Interfaces;

public interface IWebApiClient
{
	[Post("/api/employees")]
	Task PostAsync(CreateEmployeeRequest createEmployeeRequest);

    [Get("/employees/{id}")]
	Task<ApiResponse<GetEmployeeResponse>> GetByIdAsync(Guid id);

	[Get("/api/employees/{filterOption}/get-by-filter")]
	Task<ApiResponse<IEnumerable<GetEmployeeResponse>>> GetEmployeesByFilterAsync(ActiveEmployeeOptionsDto filterOption);

	[Get("/api/employees/{departmentType}/get-by-department")]
	Task<ApiResponse<IEnumerable<GetEmployeeResponse>>> GetEmployeesByDepartmentAsync(DepartmentTypeDto departmentType);

	[Delete("/api/agents/{id}")]
	Task DeleteAsync(Guid id);
}
