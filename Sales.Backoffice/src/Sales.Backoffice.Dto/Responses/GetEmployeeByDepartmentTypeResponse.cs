using Sales.Backoffice.Dto.Enums;

namespace Sales.Backoffice.Dto.Responses;

public class GetEmployeeByDepartmentTypeResponse
{
    public List<EmployeeByDepartment> Employees { get; set; }
}



public class EmployeeByDepartment()
{
    public string EmployeeName { get; set; }
    public DateTime ContractStart { get; set; }
}