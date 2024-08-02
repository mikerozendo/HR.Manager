namespace Sales.Backoffice.WebApi.Models;

public class Department : EntityBase
{
    public List<Employee> Employees { get; set; }
    public Manager Manager { get; set; }
    public string Description { get; set; }
    public decimal EmployeeBaseSalary { get; set; }
    public int MaxAcceptableEmployees { get; set; }
}
