using MediatR;
using Microsoft.AspNetCore.Mvc;
using Sales.Backoffice.Dto.Requests;
using Sales.Backoffice.Dto.Responses;
using Sales.Backoffice.WebApi.Models;
using Sales.Backoffice.WebApi.Models.Enums;
using Sales.Backoffice.WebApi.Repositories;

namespace Sales.Backoffice.WebApi.Handlers;

public class CreateEmployeeRequestHandler(ApplicationDbContext dbContext, ILogger<CreateEmployeeRequestHandler> logger) 
    : IRequestHandler<CreateEmployeeRequest, ObjectResult>
{
    private readonly ApplicationDbContext _dbContext = dbContext;
    private readonly ILogger<CreateEmployeeRequestHandler> _logger = logger;

    public async Task<ObjectResult> Handle(CreateEmployeeRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var id = Guid.NewGuid();
            var employee = new Employee()
            {
                LastName = request.LastName,
                Name = request.Name,
                Id = id,
                Documents = new List<Document>
            {
                new (){DocumentType =  DocumentType.Cpf,Number = request.Cpf },
                new (){DocumentType =  DocumentType.Rg,Number = request.Rg },
            }
            };

            await _dbContext.Employees.AddAsync(employee, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return new OkObjectResult(new EntityCreatedResponse(id));
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "[Handler]", nameof(CreateEmployeeRequestHandler));
            throw;
        }
    }
}
