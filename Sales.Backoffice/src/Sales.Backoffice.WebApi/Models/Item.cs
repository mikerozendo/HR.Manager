namespace Sales.Backoffice.WebApi.Models;

public class Item
{
    public Product Product { get; set; }
    public int Quantity { get; set; }
    public decimal TotalAmout { get; set; }
}
