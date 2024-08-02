namespace Sales.Backoffice.WebApi.Models;

public class SalesAgent : Employee
{
    public List<Sale> Sale { get; set; }
    public decimal ComissionAmount { get; set; } }
