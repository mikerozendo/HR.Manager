using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Sales.Backoffice.Application.Mappers;
using Sales.Backoffice.Dto.Requests.Commands;
using Sales.Backoffice.Dto.Responses;
using Sales.Backoffice.Model.Enums;
using Sales.Backoffice.Repository.Internal.Interfaces;

namespace Sales.Backoffice.Application.Handlers.Commands;

public class CreateEmployeeRequestHandler : IRequestHandler<CreateEmployeeRequest, ObjectResult>
{

    private readonly IEmployeeRepository _employeeRepository;
    private readonly IDepartmentRepository _departmentRepository;
    private readonly IDocumentRepository _documentRepository;
    private readonly ILogger<CreateEmployeeRequestHandler> _logger;

    public CreateEmployeeRequestHandler(
        ILogger<CreateEmployeeRequestHandler> logger,
        IEmployeeRepository employeeRepository,
        IDepartmentRepository departmentRepository,
        IDocumentRepository documentRepository)
    {
        _employeeRepository = employeeRepository;
        _departmentRepository = departmentRepository;
        _documentRepository = documentRepository;
        _logger = logger;
    }

    public async Task<ObjectResult> Handle(CreateEmployeeRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var department = await _departmentRepository.GetByTypeAsync((DepartmentType)request.DepartmentType);
            if (department is null)
                return new UnprocessableEntityObjectResult("The specified department does not even exist");

            var documentNumbers = request.DocumentList.Select(x => x.Number).ToArray();
            var doesEmployeeAlreadyExists = await _documentRepository.GetDocumentsByNumbersAsync(documentNumbers);
            if (doesEmployeeAlreadyExists.Count > 0)
                return new UnprocessableEntityObjectResult($"The person already exist");


            var employee = request.ToModel(department);
            employee.CreatedAt = DateTime.Now;

            await _employeeRepository.CreateAsync(employee);
            return new OkObjectResult(new EntityAcceptedResponse(employee.Id));
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while trying to create a new employee");
            throw;
        }
    }
}
