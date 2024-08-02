using Refit;
using Sales.Backoffice.Application.HttpClients;
using Sales.Backoffice.Application.RequestModels;

namespace Sales.Backoffice.Application.Services;

public class EmployeeService : IEmployeeService
{
    private readonly IEmployeeHttpClient _httpClient;

    public EmployeeService(IEmployeeHttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<ApiResponse<EmployeeRequest>> PostAsync(EmployeeRequest EmployeeRequest)
    {
        var response = await _httpClient.Post(EmployeeRequest);
        return response;
    }

    public async Task<ApiResponse<List<EmployeeRequest>>> GetAsync()
    {
        var response = await _httpClient.Get();
        return response;
    }
}
