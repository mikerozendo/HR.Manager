namespace Sales.Backoffice.Model;

public class SalesAgent : Employee
{
    public List<Sale> Sale { get; set; }
    public decimal ComissionAmount { get; set; }
}
