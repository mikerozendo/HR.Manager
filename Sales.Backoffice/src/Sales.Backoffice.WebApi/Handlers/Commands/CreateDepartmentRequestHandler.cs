using MediatR;
using Microsoft.AspNetCore.Mvc;
using Sales.Backoffice.Dto.Requests.Commands;
using Sales.Backoffice.Model;
using Sales.Backoffice.Model.Enums;
using Sales.Backoffice.Repository.Internal.Interfaces;

namespace Sales.Backoffice.WebApi.Handlers.Commands;

public class CreateDepartmentRequestHandler : IRequestHandler<CreateDepartmentRequest, ObjectResult>
{
    private readonly ILogger<CreateDepartmentRequestHandler> _logger;
    private readonly IDepartmentRepository _departmentRepository;

    public CreateDepartmentRequestHandler(ILogger<CreateDepartmentRequestHandler> logger, IDepartmentRepository departmentRepository)
    {
        _logger = logger;
        _departmentRepository = departmentRepository;
    }

    public async Task<ObjectResult> Handle(CreateDepartmentRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var departmentType = (DepartmentType)request.DepartmentType;

            var isDepartmentAlreadyCreated = await _departmentRepository.GetByTypeAsync(departmentType);
            if (isDepartmentAlreadyCreated is not null)
                return new BadRequestObjectResult("You're trying to create a department that already exist!");

            var departmentId = Guid.NewGuid();
            var departmentModel = new Department
            {
                Id = departmentId,
                DepartmentType = departmentType,
                EmployeeBaseSalary = request.SalaryBase,
                MaxAcceptableEmployees = request.MaxAcceptableEmployees,
            };

            await _departmentRepository.CreateAsync(departmentModel);
            return new OkObjectResult("The department has been created sucessfully");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "[Handler]", nameof(CreateDepartmentRequest));
            throw;
        }
    }
}
