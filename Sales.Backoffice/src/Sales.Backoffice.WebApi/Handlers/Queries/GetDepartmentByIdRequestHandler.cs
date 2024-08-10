using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sales.Backoffice.Dto.Enums;
using Sales.Backoffice.Dto.Requests.Commands;
using Sales.Backoffice.Dto.Requests.Queries;
using Sales.Backoffice.Dto.Responses;
using Sales.Backoffice.WebApi.Repositories;

namespace Sales.Backoffice.WebApi.Handlers.Queries;

public class GetDepartmentByIdRequestHandler(ApplicationDbContext dbContext, ILogger<GetDepartmentByIdRequestHandler> logger)
    : IRequestHandler<GetDepartmentByIdRequest, ObjectResult>
{
    private readonly ApplicationDbContext _dbContext = dbContext;
    private readonly ILogger<GetDepartmentByIdRequestHandler> _logger = logger;

    public async Task<ObjectResult> Handle(GetDepartmentByIdRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var department = await _dbContext.Departments.FirstOrDefaultAsync(x => x.Id == request.Id);
            if (department is null)
                return new NotFoundObjectResult("The expected department was not found");

            return new OkObjectResult(new GetDepartmentByIdResponse()
            {
                Id = department.Id,
                DepartmentType = (DepartmentTypeDto)department.DepartmentType,
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
