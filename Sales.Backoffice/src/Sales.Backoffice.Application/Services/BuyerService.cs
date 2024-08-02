using Refit;
using Sales.Backoffice.Application.HttpClients;
using Sales.Backoffice.Models.Dto;

namespace Sales.Backoffice.Application.Services;

public class BuyerService : IBuyerService
{
    private readonly IBuyerHttpClient _httpClient;

    public BuyerService(IBuyerHttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<ApiResponse<BuyerDto>> PostAsync(BuyerDto buyerDto)
    {
        var response = await _httpClient.Post(buyerDto);
        return response;
    }
    public async Task<ApiResponse<List<BuyerDto>>> GetAsync()
    {
        var response = await _httpClient.Get();
        return response;
    }
}
