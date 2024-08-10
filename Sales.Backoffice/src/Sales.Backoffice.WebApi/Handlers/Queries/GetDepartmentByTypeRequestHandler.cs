using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sales.Backoffice.Dto.Enums;
using Sales.Backoffice.Dto.Requests.Commands;
using Sales.Backoffice.Dto.Requests.Queries;
using Sales.Backoffice.Dto.Responses;
using Sales.Backoffice.WebApi.Models.Enums;
using Sales.Backoffice.WebApi.Repositories;

namespace Sales.Backoffice.WebApi.Handlers.Queries;

public class GetDepartmentByTypeRequestHandler(ApplicationDbContext dbContext, ILogger<GetDepartmentByTypeRequestHandler> logger)
    : IRequestHandler<GetDepartmentByTypeRequest, ObjectResult>
{
    private readonly ApplicationDbContext _dbContext = dbContext;
    private readonly ILogger<GetDepartmentByTypeRequestHandler> _logger = logger;

    public async Task<ObjectResult> Handle(GetDepartmentByTypeRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var department = await _dbContext.Departments.FirstOrDefaultAsync(x => x.DepartmentType == (DepartmentType)request.Type);
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
        catch (Exception ex)
        {
            _logger.LogError(ex, "[Handler]", nameof(CreateDepartmentRequest));
            throw;
        }
    }
}
