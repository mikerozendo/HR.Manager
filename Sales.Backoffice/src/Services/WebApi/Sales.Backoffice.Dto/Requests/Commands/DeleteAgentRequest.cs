using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Sales.Backoffice.Dto.Requests.Commands;

public class DeleteAgentRequest : IRequest<ObjectResult>
{
    public DeleteAgentRequest(Guid id)
    {
        Id = id;
    }

    public Guid Id { get; set; }
}