using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Sales.Backoffice.Dto.Requests.Queries;

public class GetEmployeeByIdRequest : IRequest<ObjectResult>
{
    public GetEmployeeByIdRequest(Guid id)
    {
        EmployeeId = id;
    }

    public Guid EmployeeId { get; set; }
}