using MediatR;
using Microsoft.AspNetCore.Mvc;
using Sales.Backoffice.Dto.Enums;

namespace Sales.Backoffice.Dto.Requests.Queries;

public class GetEmployeesByDepartmentType : IRequest<ObjectResult>
{
    public GetEmployeesByDepartmentType(DepartmentTypeDto type)
    {
        Type = type;
    }

    public DepartmentTypeDto Type { get; set; }
}