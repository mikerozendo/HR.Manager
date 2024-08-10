using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Sales.Backoffice.Dto.Requests.Commands;

public class CreateDepartmentRequest : IRequest<ObjectResult>
{
    public string Description { get; set; }
    public decimal SalaryBase { get; set; }

    [AllowedValues(0, 2)]
    public int DepartmentType { get; set; }
    public int MaxAcceptableEmployees { get; set; }
}
