using MediatR;
using Microsoft.AspNetCore.Mvc;
using Sales.Backoffice.Dto.Enums;

namespace Sales.Backoffice.Dto.Requests.Queries;

public class GetEmployeesByFilterRequest(ActiveEmployeeOptionsDto employeeGetOptionsFilter) 
: IRequest<ObjectResult>
{
	public ActiveEmployeeOptionsDto EmployeeGetOptionsFilter { get; set; } = employeeGetOptionsFilter;
}
