namespace Sales.Backoffice.WebApi.Models;

public class Employee : IndividualPerson
{
    public string RegistrationCode { get; set; }
    public decimal Salary { get; set; }
    public Department Department { get; set; }
}
