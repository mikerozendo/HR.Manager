using MediatR;
using Microsoft.AspNetCore.Mvc;
using Sales.Backoffice.Dto.Enums;

namespace Sales.Backoffice.Dto.Requests.Commands;

public class UpdateDepartmentBaseSalaryRequest : IRequest<ObjectResult>
{
    public DepartmentTypeDto Type { get; set; }
    public decimal Salary { get; set; }
}
