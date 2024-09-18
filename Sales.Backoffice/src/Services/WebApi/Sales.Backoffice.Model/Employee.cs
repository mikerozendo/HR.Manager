namespace Sales.Backoffice.Model;

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
            return !EndDate.HasValue || EndDate.Value.Date > DateTime.Now.Date;
        }
    }

    public void AssignToADepartment(Department department)
    {
        Department = department;
    }

    public void WithDocuments(List<Document> documents)
    {
        Documents = documents;
    }
}