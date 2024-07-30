using Bogus;
using IdentityModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Sales.Backoffice.Identity.Data;
using Sales.Backoffice.Identity.Models;
using System.Security.Claims;

namespace Sales.Backoffice.Identity;

public class SeedData
{
    public static void SeedRoles(WebApplication app)
    {
        using var scope = app.Services.GetRequiredService<IServiceScopeFactory>().CreateScope();
        var roleMgr = scope.ServiceProvider.GetRequiredService<RoleManager<ApplicationRole>>();

        string[] roleNames =
        [
            ApplicationRole.Employee,
            ApplicationRole.Admin,
            ApplicationRole.SalesManager,
            ApplicationRole.SalesAgent,
            ApplicationRole.FinancialPerson,
            ApplicationRole.HrPerson
        ];

        foreach (var roleName in roleNames)
        {
            var roleExists = roleMgr.RoleExistsAsync(roleName).Result;
            if (!roleExists)
            {
                roleMgr.CreateAsync(new ApplicationRole { Name = roleName }).Wait();
            }
        }
    }

    public static void SeedUsers(WebApplication app)
    {
        using var scope = app.Services.GetRequiredService<IServiceScopeFactory>().CreateScope();
        try
        {
            var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            context.Database.Migrate();

            var userMgr = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            var people = new Faker<ApplicationUser>("en_US")
            .RuleFor(x => x.FirstName, f => f.Name.FirstName())
            .RuleFor(x => x.LastName, f => f.Name.LastName())
            .RuleFor(x => x.Email, f => f.Internet.Email(f.Person.FirstName).ToLower())
            .RuleFor(x => x.EmailConfirmed, true)
            .Generate(30);

            foreach (var person in people)
            {
                var user = userMgr.FindByNameAsync(person.FirstName).Result;
                if (user is null)
                {
                    person.UserName = person.FirstName.ToLower().Trim();
                    var userCreatedResult = userMgr.CreateAsync(person, "Pass123$").Result;
                    if (!userCreatedResult.Succeeded)
                        throw new InvalidOperationException("Fail while trying to generate fake users");

                    var claimCreatedResult = userMgr.AddClaimsAsync(person,
                    [
                        new Claim(JwtClaimTypes.Name, person.FirstName + person.LastName),
                        new Claim(JwtClaimTypes.GivenName, person.FirstName),
                        new Claim(JwtClaimTypes.FamilyName, person.LastName),
                    ]).Result;

                    if (!claimCreatedResult.Succeeded)
                        throw new InvalidOperationException("Fail while trying to generate fake user's claims");
                }
            }

            AssignUserToRoles(people.Take(22).ToList(), ApplicationRole.SalesAgent, userMgr);
            AssignUserToRoles(people.Skip(22).Take(5).ToList(), ApplicationRole.FinancialPerson, userMgr);
            AssignUserToRoles(people.Skip(27).Take(2).ToList(), ApplicationRole.SalesManager, userMgr);
            AssignUserToRoles(people.Skip(29).Take(1).ToList(), ApplicationRole.Admin, userMgr);
        }
        catch (Exception ex)
        {
            throw;
        }
    }

    private static void AssignUserToRoles(List<ApplicationUser> users, string userRole, UserManager<ApplicationUser> userMgr)
    {

        users.ForEach(x =>
        {
            var roleCleatedResult = userMgr.AddToRolesAsync(x,
                [
                    ApplicationRole.Employee,
                    userRole
                ]
            ).Result;

            if (!roleCleatedResult.Succeeded)
                throw new InvalidOperationException("Fail while trying to generate fake user's roles");
        });
    }
}
