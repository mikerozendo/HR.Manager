using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Sales.Backoffice.Dto.Requests.Queries;

public class GetEmployeeByIdRequest : IRequest<ObjectResult>
{
	public Guid EmployeeId { get; set; }
	
	public GetEmployeeByIdRequest(Guid id)
	{
		EmployeeId = id;
	}
}
