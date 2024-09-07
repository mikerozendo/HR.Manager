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
	
	[Get("/employees")]
	Task<ActionResult<GetEmployeeByIdResponse>> GetByIdAsync(Guid employeeId);
	
	[Get("/employees")]
	Task<ActionResult<IEnumerable<GetEmployeeByDepartmentTypeResponse>>> GetEmployeesByDepartmentAsync(DepartmentTypeDto departmentType);
	
	[Delete("/agents")]
	Task<ActionResult> DeleteAsync(Guid employeeId);
	
}
