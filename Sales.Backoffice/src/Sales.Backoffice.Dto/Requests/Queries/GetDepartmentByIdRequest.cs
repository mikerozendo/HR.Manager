using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Sales.Backoffice.Dto.Requests.Queries;

public class GetDepartmentByIdRequest : IRequest<ObjectResult>
{
    public Guid Id { get; set; }
    public GetDepartmentByIdRequest(Guid id)
    {
        Id = id;
    }
}
