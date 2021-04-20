using LoadResourceTest.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace LoadResourceTest.Database
{
  public class EmployeeContext : DbContext
  {

    public DbSet<Employee> Employees { get; set; }
    public DbSet<BiggestSecret> Secrets { get; set; }
    public DbSet<Contract> Contracts { get; set; }
    public DbSet<Pet> Pets { get; set; }
    private ILoggerFactory _logger { get; set; }
    public EmployeeContext(DbContextOptions<EmployeeContext> options, ILoggerFactory factory) : base(options)
    {
      _logger = factory;
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

      modelBuilder.Entity<Employee>()
          .HasMany(b => b.Pets)
          .WithOne(i => i.Employee)
          .HasForeignKey(b => b.EmployeeId);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      base.OnConfiguring(optionsBuilder);
      optionsBuilder.UseLoggerFactory(_logger);
    }


  }
}