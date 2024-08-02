using Refit;
using Sales.Backoffice.Application.HttpClients;
using Sales.Backoffice.Dto.Requests;

namespace Sales.Backoffice.Application.Services;

public class EmployeeService : IEmployeeService
{
    private readonly IEmployeeHttpClient _httpClient;

    public EmployeeService(IEmployeeHttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<ApiResponse<CreateEmployeeRequest>> PostAsync(CreateEmployeeRequest CreateEmployeeRequest)
    {
        var response = await _httpClient.Post(CreateEmployeeRequest);
        return response;
    }

    public async Task<ApiResponse<List<CreateEmployeeRequest>>> GetAsync()
    {
        var response = await _httpClient.Get();
        return response;
    }
}
