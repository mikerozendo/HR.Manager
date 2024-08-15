using MediatR;
using Microsoft.AspNetCore.Mvc;
using Sales.Backoffice.Dto.Requests.Queries;
using Sales.Backoffice.Model.Enums;
using Sales.Backoffice.Repository;
using Sales.Backoffice.Repository.Internal.Interfaces;

namespace Sales.Backoffice.WebApi.Handlers.Queries;

public class GetEmployeesByDepartmentTypeRequestHandler : IRequestHandler<GetEmployeesByDepartmentType, ObjectResult>
{
    private readonly ApplicationDbContext _context;
    private readonly IEmployeeRepository _employeeRepository;
    public GetEmployeesByDepartmentTypeRequestHandler(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<ObjectResult> Handle(GetEmployeesByDepartmentType request, CancellationToken cancellationToken)
    {
        try
        {
            var employees = await _employeeRepository.GetByDepartmentAsync((DepartmentType)request.Type);

            if (employees.Count == 0)
                return new NotFoundObjectResult("There aren't employees for this department yet.");

            throw new NotImplementedException();    
        }
        catch (Exception ex)
        {
            throw;
        }
    }
}
