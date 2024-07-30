using Microsoft.AspNetCore.Identity;

namespace Sales.Backoffice.Identity.Models;

public class ApplicationUser : IdentityUser<Guid>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
}
