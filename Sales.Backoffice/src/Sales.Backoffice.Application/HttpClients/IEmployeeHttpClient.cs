using Refit;
using Sales.Backoffice.Dto.Requests;
using Sales.Backoffice.Dto.Responses;

namespace Sales.Backoffice.Application.HttpClients;

[Headers("accept: application/json","Authorization: Bearer")]
public interface IEmployeeHttpClient
{
    [Post("/Employee")]
    Task<ApiResponse<EntityCreatedResponse>> Post(CreateEmployeeRequest input);

    //[Get("/Employee")]
    //Task<ApiResponse<List<CreateEmployeesResponse>>> Get();
}
