using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sales.Backoffice.Dto.Enums;
using Sales.Backoffice.Dto.Requests.Commands;
using Sales.Backoffice.Dto.Requests.Queries;
using Sales.Backoffice.Dto.Responses;

namespace Sales.Backoffice.WebApi.Controllers;

[Authorize]
[ApiController]
[Route("api/employees")]
[ProducesResponseType(StatusCodes.Status401Unauthorized)]
public class EmployeeController(IMediator mediator) : ControllerBase
{
    [HttpGet("{id}")]
	[ProducesResponseType(StatusCodes.Status200OK)]
	[ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
	public async Task<IActionResult> GetById([FromRoute] Guid id, CancellationToken cancellationToken)
	{
		return await mediator.Send(new GetEmployeeByIdRequest(id), cancellationToken);
	}

	[HttpPost]
	[ProducesResponseType(typeof(EntityAcceptedResponse), StatusCodes.Status201Created)]
	[ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
	public async Task<IActionResult> Post([FromBody] CreateEmployeeRequest request, CancellationToken cancellationToken)
	{
		var response = await mediator.Send(request, cancellationToken);
		if (response is OkObjectResult)
		{
			return Created(nameof(GetById), response.Value);
		}

		return response;
	}

	[HttpGet("{departmentType}/get-by-department")]
	[ProducesResponseType(StatusCodes.Status200OK)]
	[ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
	public async Task<IActionResult> GetByDepartment([FromRoute] DepartmentTypeDto departmentType, CancellationToken cancellationToken)
	{
		return await mediator.Send(new GetEmployeesByDepartmentType(departmentType), cancellationToken);
	}
}
