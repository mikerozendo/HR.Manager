using Microsoft.AspNetCore.Mvc;
using Refit;
using Sales.Backoffice.Dto.Enums;
using Sales.Backoffice.Dto.Requests.Commands;
using Sales.Backoffice.Dto.Responses;

namespace Sales.Backoffice.Web.Repositories.Interfaces;


public interface IWebApiClient
{
	[Post("/api/employees")]
	Task<ActionResult> PostAsync(CreateEmployeeRequest createEmployeeRequest);
	
	[Get("/employees/{id}")]
	Task<ActionResult<GetEmployeeResponse>> GetByIdAsync(Guid id);
	
	[Get("/api/employees/{filterOption}/get-by-filter")]
	Task<ActionResult<IEnumerable<GetEmployeeByDepartmentTypeResponse>>> GetEmployeesByFilterAsync(ActiveEmployeeOptionsDto filterOption);
	
	[Get("/api/employees/{departmentType}/get-by-department")]
	Task<ActionResult<IEnumerable<GetEmployeeByDepartmentTypeResponse>>> GetEmployeesByDepartmentAsync(DepartmentTypeDto departmentType);
	
	[Delete("/api/agents/{id}")]
	Task<ActionResult> DeleteAsync(Guid id);
}
