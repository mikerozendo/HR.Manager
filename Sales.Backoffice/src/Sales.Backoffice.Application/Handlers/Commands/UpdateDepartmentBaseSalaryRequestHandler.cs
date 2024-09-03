using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Sales.Backoffice.Dto.Requests.Commands;
using Sales.Backoffice.Dto.Responses;
using Sales.Backoffice.Model.Enums;
using Sales.Backoffice.Repository.Internal.Interfaces;

namespace Sales.Backoffice.Application.Handlers.Commands;

public class UpdateDepartmentBaseSalaryRequestHandler : IRequestHandler<UpdateDepartmentBaseSalaryRequest, ObjectResult>
{
	private readonly IDepartmentRepository _departmentRepository;
	private readonly ILogger<UpdateDepartmentBaseSalaryRequestHandler> _logger;

	public UpdateDepartmentBaseSalaryRequestHandler(
		ILogger<UpdateDepartmentBaseSalaryRequestHandler> logger,
		IDepartmentRepository departmentRepository)
	{
		_departmentRepository = departmentRepository;
		_logger = logger;
	}

	public async Task<ObjectResult> Handle(UpdateDepartmentBaseSalaryRequest request, CancellationToken cancellationToken)
	{
		var department = await _departmentRepository.GetByTypeAsync((DepartmentType)request.Type);
		if (department == null)
		{
			return new NotFoundObjectResult("The required department was not found");
		}
		
		department.EmployeeBaseSalary = request.Salary;
		await _departmentRepository.UpdateAsync(department);
		return new OkObjectResult(new EntityAcceptedResponse(department.Id));
	}
}
