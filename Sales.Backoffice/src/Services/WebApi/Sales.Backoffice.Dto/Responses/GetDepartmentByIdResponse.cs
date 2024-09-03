using Sales.Backoffice.Dto.Enums;

namespace Sales.Backoffice.Dto.Responses;

public class GetDepartmentByIdResponse
{
    public Guid Id { get; set; }
    public DepartmentTypeDto DepartmentType { get; set; }
    public string Description { get; set; }
    public decimal SalaryBase { get; set; }
    public int MaxAcceptableEmployees { get; set; }
}
