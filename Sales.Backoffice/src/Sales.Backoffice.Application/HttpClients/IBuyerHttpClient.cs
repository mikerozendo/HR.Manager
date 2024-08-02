using Refit;
using Sales.Backoffice.Models.Dto;

namespace Sales.Backoffice.Application.HttpClients;

[Headers("accept: application/json",
    "Authorization: Bearer")]
public interface IBuyerHttpClient
{
    [Post("/buyer/")]
    Task<ApiResponse<BuyerDto>> Post(BuyerDto input);

    [Get("/Buyer/GetBuyers")]
    Task<ApiResponse<List<BuyerDto>>> Get();
}
