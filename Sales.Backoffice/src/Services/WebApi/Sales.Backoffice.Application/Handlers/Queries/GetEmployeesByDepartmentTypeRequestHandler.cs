using MediatR;
using Microsoft.AspNetCore.Mvc;
using Sales.Backoffice.Dto.Requests.Queries;
using Sales.Backoffice.Model.Enums;
using Sales.Backoffice.Repository.Internal.Interfaces;

namespace Sales.Backoffice.Application.Handlers.Queries;

public class GetEmployeesByDepartmentTypeRequestHandler(IEmployeeRepository employeeRepository) 
: IRequestHandler<GetEmployeesByDepartmentType, ObjectResult>
{
	public async Task<ObjectResult> Handle(GetEmployeesByDepartmentType request, CancellationToken cancellationToken)
	{
		try
		{
			var employees = await employeeRepository.GetByDepartmentAsync((DepartmentType)request.Type);

			if (employees.Count == 0)
				return new NotFoundObjectResult("There aren't employees for this department yet.");

			throw new NotImplementedException();
		}
		catch (Exception ex)
		{
			throw;
		}
	}
}
