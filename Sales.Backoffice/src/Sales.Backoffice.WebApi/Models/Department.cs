namespace Sales.Backoffice.WebApi.Models;

public class Department : EntityBase
{
    public List<Employee> Employees { get; set; }
    public Manager Manager { get; set; }
}
