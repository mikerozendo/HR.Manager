using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sales.Backoffice.Dto.Requests.Queries;
using Sales.Backoffice.WebApi.Models.Enums;
using Sales.Backoffice.WebApi.Repositories;

namespace Sales.Backoffice.WebApi.Handlers.Queries;

public class GetEmployeesByDepartmentTypeRequestHandler : IRequestHandler<GetEmployeesByDepartmentType, ObjectResult>
{
    private readonly ApplicationDbContext _context;
    public GetEmployeesByDepartmentTypeRequestHandler(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<ObjectResult> Handle(GetEmployeesByDepartmentType request, CancellationToken cancellationToken)
    {
        try
        {
            var employees = await _context.Employees
                 .Where(x => x.Department.DepartmentType == (DepartmentType)request.Type)
                 .ToListAsync();

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
