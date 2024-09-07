using Sales.Backoffice.Model.Enums;

namespace Sales.Backoffice.Model;

public class Department : EntityBase
{
    public List<Employee> Employees { get; set; }
    public Manager Manager { get; set; }
    public decimal EmployeeBaseSalary { get; set; }
    public int MaxAcceptableEmployees { get; set; }
    public DepartmentType DepartmentType { get; set; }
}