using MediatR;
using Microsoft.AspNetCore.Mvc;
using Sales.Backoffice.Dto.Enums;

namespace Sales.Backoffice.Dto.Requests.Queries;

public class GetEmployeesByDepartmentType : IRequest<ObjectResult>
{
    public DepartmentTypeDto Type { get; set; }
    public GetEmployeesByDepartmentType(DepartmentTypeDto type)
    {
        Type = type;
    }
}