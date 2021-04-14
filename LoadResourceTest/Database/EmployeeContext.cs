using LoadResourceTest.Entities;
using Microsoft.EntityFrameworkCore;

namespace LoadResourceTest.Database
{
  public class EmployeeContext : DbContext
  {

    public DbSet<Employee> Employees { get; set; }
    public DbSet<BiggestSecret> Secrets { get; set; }
    public DbSet<Contract> Contracts { get; set; }
    public EmployeeContext(DbContextOptions<EmployeeContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<Employee>()
           .HasOne(b => b.ActiveContract)
           .WithOne(i => i.Employee)
           .HasForeignKey<Contract>(b => b.EmployeeId);

      modelBuilder.Entity<Employee>()
          .HasOne(b => b.Secret)
          .WithOne(i => i.Employee)
          .HasForeignKey<BiggestSecret>(b => b.EmployeeId);
    }


  }
}