using Sales.Backoffice.Dto.Enums;

namespace Sales.Backoffice.Dto.Responses;

public class GetEmployeeResponse
{
    public string Name { get; set; }
    public string LastName { get; set; }
    public DateTime BirthDate { get; set; }
    public DateTime ContractStart { get; set; }
    public DateTime? ContractEnd { get; set; }
    public SexTypeDto SexType { get; set; }
    public DepartmentTypeDto DepartmentType { get; set; }
}