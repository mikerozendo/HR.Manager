using Sales.Backoffice.Model.Enums;

namespace Sales.Backoffice.Model;

public class Sale : RegisterBase
{
    public SalesAgent SalesAgent { get; set; }
    public decimal TotalAmount { get; set; }
    public SaleStatus SaleStatus { get; set; }
    public Client Client { get; set; }
    public List<SaleItem> SaleItems { get; set; }
}
