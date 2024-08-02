using Refit;
using Sales.Backoffice.Dto.Requests;

namespace Sales.Backoffice.Application.HttpClients;

[Headers("accept: application/json","Authorization: Bearer")]
public interface IEmployeeHttpClient
{
    [Post("/Employee/")]
    Task<ApiResponse<CreateEmployeeRequest>> Post(CreateEmployeeRequest input);

    [Get("/Employee/")]
    Task<ApiResponse<List<CreateEmployeeRequest>>> Get();
}
