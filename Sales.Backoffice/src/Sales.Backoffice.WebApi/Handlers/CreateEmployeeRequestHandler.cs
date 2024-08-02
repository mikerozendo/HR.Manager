using FluentResults;
using MediatR;
using Sales.Backoffice.Dto.Requests;
using Sales.Backoffice.WebApi.Models;
using Sales.Backoffice.WebApi.Models.Enums;
using Sales.Backoffice.WebApi.Repositories;

namespace Sales.Backoffice.WebApi.Handlers;

public class CreateEmployeeRequestHandler : IRequestHandler<CreateEmployeeRequest, Result>
{
    private readonly ApplicationDbContext _dbContext;
    public CreateEmployeeRequestHandler(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Result> Handle(CreateEmployeeRequest request, CancellationToken cancellationToken)
    {
        var employee = new Employee()
        {
            Name = request.Name,
            LastName = request.LastName,
            Id = Guid.NewGuid(),
            Documents = new List<Document>
            {
                new (){DocumentType =  DocumentType.Cpf,Number = request.Cpf },
                new (){DocumentType =  DocumentType.Rg,Number = request.Rg },
            }
        };


        await _dbContext.Employees.AddAsync(employee);
        return Result.Ok();
    }
}
