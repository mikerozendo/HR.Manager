using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sales.Backoffice.Dto.Requests.Commands;
using Sales.Backoffice.Dto.Responses;
using Sales.Backoffice.WebApi.Models;
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

            var doesEmployeeAlreadyExists = await _dbContext.Documents
                .Where(x => x.Number.Equals(request.Cpf) || x.Number.Equals(request.Rg))
                .ToListAsync();

            if (doesEmployeeAlreadyExists.Count > 0)
                return new UnprocessableEntityObjectResult($"The person already exist with Id {doesEmployeeAlreadyExists.First().AgentId}");

            var registerDate = DateTime.Now;
            var id = Guid.NewGuid();
            var contacts = request.PersonContactList?.Select(x => new Contact
            {
                ContactType = (ContactType)x.Type,
                Id = Guid.NewGuid(),
                Value = x.Contact
            });
            var documents = new List<Document>()
                {
                    new (){DocumentType =  DocumentType.Cpf,Number = request.Cpf },
                    new (){DocumentType =  DocumentType.Rg,Number = request.Rg },
                };

            var employee = new Employee()
            {
                Id = id,
                LastName = request.LastName,
                Name = request.Name,
                CreatedAt = registerDate,
                BirthDate = DateTime.Now.AddYears(-18).Date,
                StartDate = DateTime.Now.AddDays(2),
                IsActive = true,
                ModifiedAt = registerDate,
                DepartmentId = department.Id,
            };

            employee.WithContacts(contacts.ToList());
            employee.WithDocuments(documents.ToList());
            employee.WithCreatedDate(registerDate);
            employee.WithModifiedDate(registerDate);

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
