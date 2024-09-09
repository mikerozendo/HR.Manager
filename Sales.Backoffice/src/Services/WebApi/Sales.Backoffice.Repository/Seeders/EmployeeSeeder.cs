using Bogus;
using Bogus.Extensions.Brazil;
using Microsoft.Extensions.DependencyInjection;
using Sales.Backoffice.Model;
using Sales.Backoffice.Model.Enums;
using Sales.Backoffice.Repository.Internal.Interfaces;

namespace Sales.Backoffice.Repository.Seeders;

public static class EmployeeSeeder
{
    public static async Task SeedAsync(this IServiceProvider serviceProvider)
    {
        try
        {
            var departmentRepository = serviceProvider.GetRequiredService<IDepartmentRepository>();
            var employeeRepository = serviceProvider.GetRequiredService<IEmployeeRepository>();
            using var context = serviceProvider.GetRequiredService<ApplicationDbContext>();

            var sallesDepartment = await departmentRepository.GetByTypeAsync(DepartmentType.Sales);
            var hrDepartment = await departmentRepository.GetByTypeAsync(DepartmentType.HR);
            var financialDapartment = await departmentRepository.GetByTypeAsync(DepartmentType.Financial);
            var sallesManagementDepartment = await departmentRepository.GetByTypeAsync(DepartmentType.SalesManagement);


            var employees = new Faker<Employee>("en_US")
            .RuleFor(x => x.Name, f => f.Name.FirstName())
            .RuleFor(x => x.LastName, f => f.Name.LastName())
            .RuleFor(x => x.Sex, f => (SexType)f.Person.Gender)
            .RuleFor(x => x.PersonType, AgentType.Individual)
            .RuleFor(x => x.BirthDate, f => f.Person.DateOfBirth)
            .RuleFor(x => x.CreatedAt, DateTime.Now)
            .RuleFor(x => x.StartDate, DateTime.Now.AddYears(-1))
            .Generate(50);


            employees.Take(40).ToList().ForEach(x => { x.DepartmentId = sallesDepartment.Id; });
            employees.Skip(40).Take(4).ToList().ForEach(x => { x.DepartmentId = sallesManagementDepartment.Id; });
            employees.Skip(44).Take(3).ToList().ForEach(x => { x.DepartmentId = hrDepartment.Id; });
            employees.Skip(47).Take(3).ToList().ForEach(x => { x.DepartmentId = financialDapartment.Id; });


            foreach (var employee in employees)
            {
                var contacts = new Faker<Contact>("en_US")
                .RuleFor(x => x.Value, f => f.Phone.PhoneNumber())
                .RuleFor(x => x.ContactType, ContactType.CellPhone)
                .Generate(1);

                contacts.Concat(new Faker<Contact>("en_US")
                .RuleFor(x => x.Value, f => f.Internet.Email())
                .Generate(1));

                var adresses = new Faker<Adress>("en_US")
                .RuleFor(x => x.AdressCategory, AdressCategory.Primary)
                .RuleFor(x => x.City, f => f.Address.City())
                .RuleFor(x => x.Number, f => f.Address.BuildingNumber())
                .RuleFor(x => x.Street, f => f.Address.StreetAddress())
                .RuleFor(x => x.ZipCode, f => f.Address.ZipCode())
                .RuleFor(x => x.State, f => f.Address.State())
                .RuleFor(x => x.AdressType, AdressType.Personal).Generate(1);

                var documents = new Faker<Document>("en_US")
                .RuleFor(x => x.Number, f => f.Person.Cpf())
                .RuleFor(x => x.DocumentType, DocumentType.Cpf).Generate(1);

                employee.WithDocuments(documents);
                employee.WithAdresses(adresses);
                employee.WithContacts(contacts);
            }

            await context.Employees.AddRangeAsync(employees);
            await context.SaveChangesAsync();
        }
        catch (System.Exception ex)
        {
            throw;
        }
    }
}
