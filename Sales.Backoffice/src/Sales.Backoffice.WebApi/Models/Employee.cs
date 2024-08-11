namespace Sales.Backoffice.WebApi.Models;

public class Employee : IndividualPerson
{
    public Department Department { get; set; }
    public Guid DepartmentId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public bool IsActive
    {
        get
        {
            if (EndDate.HasValue && EndDate.Value.Date <= DateTime.Now.Date)
                return false;

            return true;
        }
    }

    public Employee() : base() { }

    public void AssignToADepartment(Department department)
    {
        Department = department;
    }
}
