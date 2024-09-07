using MediatR;
using Microsoft.AspNetCore.Mvc;
using Sales.Backoffice.Application.Mappers;
using Sales.Backoffice.Dto.Requests.Queries;
using Sales.Backoffice.Dto.Enums;
using Sales.Backoffice.Model;
using Sales.Backoffice.Repository.Internal.Interfaces;

namespace Sales.Backoffice.Application.Handlers.Queries;

public class GetEmployeesByFilterRequestHandler(IEmployeeRepository employeeRepository) : IRequestHandler<GetEmployeesByFilterRequest, ObjectResult>
{
    public async Task<ObjectResult> Handle(GetEmployeesByFilterRequest request, CancellationToken cancellationToken)
	{
		var employees = request.EmployeeGetOptionsFilter switch
		{
            ActiveEmployeeOptionsDto.OnlyActive => await employeeRepository.GetActiveEmployeesAsync(),
			ActiveEmployeeOptionsDto.OnlyInactive => await employeeRepository.GetNonActiveEmployeesAsync(),
			_ => await employeeRepository.GetAllAsync(),
		};

		if (employees == Enumerable.Empty<Employee>())
			return new NotFoundObjectResult("There aren't any employees with the filter sent");

		return new OkObjectResult(employees.Select(x => x.ToDto()));
	}
}
