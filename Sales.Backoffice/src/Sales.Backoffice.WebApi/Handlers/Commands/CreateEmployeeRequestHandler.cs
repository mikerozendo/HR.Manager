using MediatR;
using Microsoft.AspNetCore.Mvc;
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
            var registerDate = DateTime.Now;
            var id = Guid.NewGuid();
            var contacts = request.PersonContactList?.Select(x => new Contact
            {
                ContactType = (ContactType)x.Type,
                Id = Guid.NewGuid(),
                CreatedAt = registerDate,
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
                //BirthDate = request.BirthDate,
                BirthDate = DateTime.Now.AddYears(-18),
                RegistrationCode = Guid.NewGuid().ToString(),
                IsActive = true,
                ModifiedAt = registerDate,

            };
            employee.WithContacts(contacts.ToList());
            employee.WithDocuments(documents.ToList());


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
