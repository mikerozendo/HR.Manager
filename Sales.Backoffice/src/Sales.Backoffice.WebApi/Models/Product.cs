using Sales.Backoffice.WebApi.Models.Enums;

namespace Sales.Backoffice.WebApi.Models;

public class Product : RegisterBase
{
    public ProductAvailability ProductAvailability { get; set; }
    public decimal AquisitionCost { get; set; }
    public decimal SalesValue { get; set; }
}
