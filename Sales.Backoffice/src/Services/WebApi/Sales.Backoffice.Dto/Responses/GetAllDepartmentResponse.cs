using Sales.Backoffice.Dto.Enums;

namespace Sales.Backoffice.Dto.Responses;

public class GetAllDepartmentResponse
{
    public Guid Id { get; set; }
    public DepartmentTypeDto DepartmentType { get; set; }

}
