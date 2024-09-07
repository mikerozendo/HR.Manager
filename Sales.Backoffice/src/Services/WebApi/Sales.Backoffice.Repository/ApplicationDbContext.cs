using Microsoft.EntityFrameworkCore;
using Sales.Backoffice.Model;
using Sales.Backoffice.Repository.Mappers;

namespace Sales.Backoffice.Repository;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
	public DbSet<Document> Documents { get; set; }
	public DbSet<Adress> Adresses { get; set; }
	public DbSet<Agent> Agents { get; set; }
	public DbSet<Contact> Contacts { get; set; }
	public DbSet<IndividualPerson> IndividualPersons { get; set; }
	public DbSet<Employee> Employees { get; set; }
	public DbSet<Department> Departments { get; set; }
	
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