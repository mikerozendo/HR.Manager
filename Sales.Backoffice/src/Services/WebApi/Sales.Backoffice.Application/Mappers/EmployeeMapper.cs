using Sales.Backoffice.Dto.Enums;
using Sales.Backoffice.Dto.Requests.Commands;
using Sales.Backoffice.Dto.Responses;
using Sales.Backoffice.Model;
using Sales.Backoffice.Model.Enums;

namespace Sales.Backoffice.Application.Mappers;

public static class EmployeeMapper
{
    public static Employee ToModel(this CreateEmployeeRequest createEmployeeRequest, Department department)
    {
        var employee = new Employee
        {
            BirthDate = createEmployeeRequest.BirthDate.Date,
            Name = createEmployeeRequest.Name,
            LastName = createEmployeeRequest.LastName,
            Sex = (SexType)createEmployeeRequest.SexType,
            StartDate = createEmployeeRequest.ContractStart.Date,
            DepartmentId = department.Id
        };

        employee.WithContacts(createEmployeeRequest.PersonContactList.ToModel());
        employee.WithDocuments(createEmployeeRequest.DocumentList.ToModel());

        return employee;
    }

    public static GetEmployeeByIdResponse ToDto(this Employee employeeModel)
    {
        var employee = new GetEmployeeByIdResponse
        {
            BirthDate = employeeModel.BirthDate.Date,
            Name = employeeModel.Name,
            LastName = employeeModel.LastName,
            SexType = (SexTypeDto)employeeModel.Sex,
            ContractStart = employeeModel.StartDate.Date,
            DepartmentType = (DepartmentTypeDto)employeeModel.Department.DepartmentType
        };

        return employee;
    }
}