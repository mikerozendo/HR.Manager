using MediatR;
using Microsoft.AspNetCore.Mvc;
using Sales.Backoffice.Dto.Enums;

namespace Sales.Backoffice.Dto.Requests.Queries;

public class GetDepartmentByTypeRequest : IRequest<ObjectResult>
{
    public DepartmentTypeDto Type { get; set; }
    public GetDepartmentByTypeRequest(DepartmentTypeDto type)
    {
        Type = type;
    }
}
