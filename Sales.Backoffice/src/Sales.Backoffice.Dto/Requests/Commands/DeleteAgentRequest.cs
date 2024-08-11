using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Sales.Backoffice.Dto.Requests.Commands;

public class DeleteAgentRequest : IRequest<ObjectResult>
{
    public Guid Id { get; set; }
	public DeleteAgentRequest(Guid id)
	{
        Id = id;
    }
}
