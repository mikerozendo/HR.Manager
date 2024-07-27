using Sales.Backoffice.Repositories.External;

namespace Sales.Backoffice.Application.UseCases;

public class HealthCheckUseCase : IHealthCheckUseCase
{
    private readonly IHealthCheckRepository _healthCheckRepository;

    public HealthCheckUseCase(IHealthCheckRepository healthCheckRepository)
    {
        _healthCheckRepository = healthCheckRepository;
    }

    public async Task GetAsync()
    {
       await _healthCheckRepository.GetAsync();
    }
}
