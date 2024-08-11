using Sales.Backoffice.Dto.Requests.Commands;
using Sales.Backoffice.Model;
using Sales.Backoffice.Model.Enums;

namespace Sales.Backoffice.WebApi.Mappers;

public static class EmployeeMapper
{
    public static Employee ToModel(this CreateEmployeeRequest createEmployeeRequest, Department department)
    {
        var employee = new Employee()
        {
            BirthDate = createEmployeeRequest.BirthDate,
            Name = createEmployeeRequest.Name,
            LastName = createEmployeeRequest.LastName,
            Sex = (SexType)createEmployeeRequest.SexType,
            StartDate = createEmployeeRequest.ContractStart,
            DepartmentId = department.Id,
        };

        employee.WithContacts(createEmployeeRequest.PersonContactList.ToModel());
        employee.WithDocuments(createEmployeeRequest.DocumentList.ToModel());

        return employee;
    }
}
