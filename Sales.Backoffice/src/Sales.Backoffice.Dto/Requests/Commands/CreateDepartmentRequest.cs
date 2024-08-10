using MediatR;
using Microsoft.AspNetCore.Mvc;
using Sales.Backoffice.Dto.Enums;

namespace Sales.Backoffice.Dto.Requests.Commands;

public class CreateDepartmentRequest : IRequest<ObjectResult>
{
    public decimal SalaryBase { get; set; }
    public DepartmentTypeDto DepartmentType { get; set; }
    public int MaxAcceptableEmployees { get; set; }
}
