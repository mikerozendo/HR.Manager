using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sales.Backoffice.Dto.Requests.Commands;
using Sales.Backoffice.Dto.Responses;
using Sales.Backoffice.WebApi.Mappers;
using Sales.Backoffice.WebApi.Models.Enums;
using Sales.Backoffice.WebApi.Repositories;

namespace Sales.Backoffice.WebApi.Handlers.Commands;

public class CreateEmployeeRequestHandler(ApplicationDbContext dbContext, ILogger<CreateEmployeeRequestHandler> logger)
    : IRequestHandler<CreateEmployeeRequest, ObjectResult>
{
    private readonly ApplicationDbContext _dbContext = dbContext;
    private readonly ILogger<CreateEmployeeRequestHandler> _logger = logger;

    public async Task<ObjectResult> Handle(CreateEmployeeRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var department = await _dbContext.Departments.SingleOrDefaultAsync(
                x => x.DepartmentType == (DepartmentType)request.DepartmentType
            );

            if (department is null)
                return new UnprocessableEntityObjectResult("The specified department does not even exist");

            var documentNumbers = request.DocumentList.Select(x => x.Number).ToList();
            var doesEmployeeAlreadyExists = await _dbContext.Documents.AnyAsync(x => documentNumbers.Contains(x.Number));
            if (doesEmployeeAlreadyExists)
                return new UnprocessableEntityObjectResult($"The person already exist");


            var employee = request.ToModel(department);
            employee.CreatedAt = DateTime.Now;

            await _dbContext.Employees.AddAsync(employee, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return new OkObjectResult(new EntityCreatedResponse(employee.Id));
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while trying to create a new employee");
            throw;
        }
    }
}
