using Microsoft.EntityFrameworkCore;
using Sales.Backoffice.WebApi.Models;
using Sales.Backoffice.WebApi.Repositories.ModelMappers;

namespace Sales.Backoffice.WebApi.Repositories;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public DbSet<Document> Documents { get; set; }
    public DbSet<Adress> Adresses { get; set; }
    public DbSet<Agent> Agents { get; set; }
    public DbSet<Contact> Contacts { get; set; }
    public DbSet<IndividualPerson> IndividualPersons { get; set; }
    public DbSet<Employee> Employees { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        //optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        //optionsBuilder.UseLazyLoadingProxies(false);
        //optionsBuilder.UseChangeTrackingProxies(false, false);
        //optionsBuilder.EnableThreadSafetyChecks(false);
        //optionsBuilder.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        DocumentMapper.Map(modelBuilder);
        AdressMapper.Map(modelBuilder);
        AgentMapper.Map(modelBuilder);
        ContactMapper.Map(modelBuilder);
        DepartmentMapper.Map(modelBuilder);
        IndividualPersonMapper.Map(modelBuilder);
        EmployeeMapper.Map(modelBuilder);   
    }
}
