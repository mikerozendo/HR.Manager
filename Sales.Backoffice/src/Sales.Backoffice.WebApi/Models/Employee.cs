namespace Sales.Backoffice.WebApi.Models;

public class Employee : IndividualPerson
{
    public Department Department { get; set; }
    public Guid DepartmentId { get; set; }
    public bool IsActive { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }

    public void WithDepartment(Department department)
    {
        Department = department;
    }
}
