using Microsoft.AspNetCore.Mvc;
using Refit;
using Sales.Backoffice.Dto.Enums;
using Sales.Backoffice.Dto.Requests.Commands;
using Sales.Backoffice.Dto.Responses;

namespace Sales.Backoffice.Web.Repositories.Interfaces;


public interface IWebApiClient
{
	[Post("/employees")]
	Task<ActionResult> PostAsync(CreateEmployeeRequest createEmployeeRequest);
	
	[Get("/employees/{id}")]
	Task<ActionResult<GetEmployeeResponse>> GetByIdAsync(Guid employeeId);
	
	[Get("/employees/{filterOption}/get-by-filter")]
	Task<ActionResult<IEnumerable<GetEmployeeByDepartmentTypeResponse>>> GetEmployeesByFilterAsync(ActiveEmployeeOptionsDto filterOption);
	
	[Get("/employees/{departmentType}/get-by-department")]
	Task<ActionResult<IEnumerable<GetEmployeeByDepartmentTypeResponse>>> GetEmployeesByDepartmentAsync(DepartmentTypeDto departmentType);
	
	[Delete("/agents")]
	Task<ActionResult> DeleteAsync(Guid employeeId);
}
