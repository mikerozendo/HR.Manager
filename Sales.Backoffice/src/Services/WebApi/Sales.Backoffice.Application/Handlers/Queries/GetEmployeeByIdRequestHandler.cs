using MediatR;
using Microsoft.AspNetCore.Mvc;
using Sales.Backoffice.Application.Mappers;
using Sales.Backoffice.Dto.Requests.Queries;
using Sales.Backoffice.Repository.Internal.Interfaces;

namespace Sales.Backoffice.Application.Handlers.Queries;

public class GetEmployeeByIdRequestHandler(IEmployeeRepository employeeRepository)
    : IRequestHandler<GetEmployeeByIdRequest, ObjectResult>
{
    public async Task<ObjectResult> Handle(GetEmployeeByIdRequest request, CancellationToken cancellationToken)
    {
        var employee = await employeeRepository.GetByIdAsync(request.EmployeeId);
        if (employee == null) return new NotFoundObjectResult("The pserson was not found");

        return new OkObjectResult(employee.ToDto());
    }
}