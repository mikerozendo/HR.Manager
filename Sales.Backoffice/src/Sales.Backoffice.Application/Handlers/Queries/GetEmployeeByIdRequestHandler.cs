using MediatR;
using Microsoft.AspNetCore.Mvc;
using Sales.Backoffice.Application.Mappers;
using Sales.Backoffice.Dto.Requests.Queries;
using Sales.Backoffice.Repository.Internal.Interfaces;

namespace Sales.Backoffice.Application.Handlers.Queries;

public class GetEmployeeByIdRequestHandler : IRequestHandler<GetEmployeeByIdRequest, ObjectResult>
{
	public IEmployeeRepository _employeeRepository { get; set; }
	public GetEmployeeByIdRequestHandler(IEmployeeRepository employeeRepository)
	{
		_employeeRepository = employeeRepository;
	}
	
	public async Task<ObjectResult> Handle(GetEmployeeByIdRequest request, CancellationToken cancellationToken)
	{
		var employee = await _employeeRepository.GetByIdAsync(request.EmployeeId);
		if (employee == null)
		{
			return new  NotFoundObjectResult("The person was not found");
		}

		return new OkObjectResult(employee.ToDto());
	}
}
