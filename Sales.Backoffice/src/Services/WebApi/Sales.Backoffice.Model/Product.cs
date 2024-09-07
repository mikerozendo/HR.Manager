using Sales.Backoffice.Model.Enums;

namespace Sales.Backoffice.Model;

public class Product : RegisterBase
{
    public ProductAvailability ProductAvailability { get; set; }
    public decimal AquisitionCost { get; set; }
    public decimal SalesValue { get; set; }
}