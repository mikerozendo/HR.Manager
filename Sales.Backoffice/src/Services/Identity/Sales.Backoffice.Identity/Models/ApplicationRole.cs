using Microsoft.AspNetCore.Identity;

namespace Sales.Backoffice.Identity.Models;

public class ApplicationRole : IdentityRole<Guid>
{
    public const string Admin = "Admin";
    public const string Employee = "Employee";
    public const string SalesManager = "SalesManager";
    public const string SalesAgent = "SalesAgent";
    public const string FinancialPerson = "FinancialPerson";
    public const string HrPerson = "HrPerson";
}
