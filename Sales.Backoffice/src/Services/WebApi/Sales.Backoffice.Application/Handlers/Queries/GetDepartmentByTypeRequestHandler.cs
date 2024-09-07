using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Sales.Backoffice.Dto.Requests.Queries;
using Sales.Backoffice.Dto.Responses;
using Sales.Backoffice.Model.Enums;
using Sales.Backoffice.Repository.Internal.Interfaces;

namespace Sales.Backoffice.Application.Handlers.Queries;

public class GetDepartmentByTypeRequestHandler : IRequestHandler<GetDepartmentByTypeRequest, ObjectResult>
{
    private readonly IDepartmentRepository _departmentRepository;
    private readonly ILogger<GetDepartmentByTypeRequestHandler> _logger;

    public GetDepartmentByTypeRequestHandler(
        IDepartmentRepository departmentRepository,
        ILogger<GetDepartmentByTypeRequestHandler> logger)
    {
        _departmentRepository = departmentRepository;
        _logger = logger;
    }

    public async Task<ObjectResult> Handle(GetDepartmentByTypeRequest request, CancellationToken cancellationToken)
    {

        var department = await _departmentRepository.GetByTypeAsync((DepartmentType)request.Type);
        if (department is null)
            return new NotFoundObjectResult("The expected department was not found");

        return new OkObjectResult(new GetDepartmentByIdResponse()
        {
            Id = department.Id,
            DepartmentType = request.Type,
            MaxAcceptableEmployees = department.MaxAcceptableEmployees,
            Description = department.DepartmentType.ToString(),
            SalaryBase = department.EmployeeBaseSalary,
        });
    }
}
