using Refit;
using Sales.Backoffice.Application.RequestModels;
using Sales.Backoffice.Application.Responses;

namespace Sales.Backoffice.Application.HttpClients;

[Headers("accept: application/json","Authorization: Bearer")]
public interface IEmployeeHttpClient
{
    [Post("/Employee/")]
    Task<ApiResponse<EmployeeResponse>> Post(EmployeeRequest input);

    [Get("/Employee/")]
    Task<ApiResponse<List<EmployeeRequest>>> Get();
}
