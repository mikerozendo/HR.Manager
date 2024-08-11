using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sales.Backoffice.Dto.Requests.Commands;
using Sales.Backoffice.Model;
using Sales.Backoffice.Model.Enums;
using Sales.Backoffice.Repository;

namespace Sales.Backoffice.WebApi.Handlers.Commands;

public class CreateDepartmentRequestHandler(ApplicationDbContext dbContext, ILogger<CreateDepartmentRequestHandler> logger)
    : IRequestHandler<CreateDepartmentRequest, ObjectResult>
{
    private readonly ApplicationDbContext _dbContext = dbContext;
    private readonly ILogger<CreateDepartmentRequestHandler> _logger = logger;

    public async Task<ObjectResult> Handle(CreateDepartmentRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var departmentType = (DepartmentType)request.DepartmentType;

            var isDepartmentAlreadyCreated = await _dbContext.Departments.SingleOrDefaultAsync(x => x.DepartmentType == departmentType);
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

            await _dbContext.Departments.AddAsync(departmentModel);
            await _dbContext.SaveChangesAsync();
            return new OkObjectResult("The department has been created sucessfully");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "[Handler]", nameof(CreateDepartmentRequest));
            throw;
        }
    }
}
