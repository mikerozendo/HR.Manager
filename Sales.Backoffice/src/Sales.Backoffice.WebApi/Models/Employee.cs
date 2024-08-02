namespace Sales.Backoffice.WebApi.Models;

public class Employee : IndividualPerson
{
    public string RegistrationCode { get; set; }
    public Department Department { get; set; }
    public Guid DepartmentId { get; set; }
    public bool IsActive { get; set; }
    public DateOnly? StartDate { get; set; }
    public DateOnly? EndDate { get; set; }
}
