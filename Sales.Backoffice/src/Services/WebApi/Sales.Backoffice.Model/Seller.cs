namespace Sales.Backoffice.Model;

public class Seller : Employee
{
    public List<Sale> Sale { get; set; }
    public decimal ComissionAmount { get; set; }
}