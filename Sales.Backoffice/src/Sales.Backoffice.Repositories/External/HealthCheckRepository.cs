using static System.Net.WebRequestMethods;

namespace Sales.Backoffice.Repositories.External;

public class HealthCheckRepository : IHealthCheckRepository
{
    public async Task GetAsync()
    {
        var endpoint = "http://localhost:5232/HealthCheck";
        var httpClient = new HttpClient();
        httpClient.BaseAddress = new Uri(endpoint);
        var response = await httpClient.GetAsync(endpoint);
        response.EnsureSuccessStatusCode();
    }
}
