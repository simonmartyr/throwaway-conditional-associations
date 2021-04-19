using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LoadResourceTest.Database;
using LoadResourceTest.Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace LoadResourceTest
{
  public class Program
  {
    public static void Main(string[] args)
    {
      var host = CreateHostBuilder(args).Build();

      CreateDbIfNotExists(host);

      host.Run();
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder =>
            {
              webBuilder.UseStartup<Startup>();
            });

    private static void CreateDbIfNotExists(IHost host)
    {
      using (var scope = host.Services.CreateScope())
      {
        var services = scope.ServiceProvider;
        try
        {
          var context = services.GetRequiredService<EmployeeContext>();
          context.Database.EnsureCreated();
          if (context.Employees.Any())
            return;

          var kevin = new Employee
          {
            Name = "Kevin",
            Age = 22,
            Secret = new BiggestSecret
            {
              Secret = "scared of rebasing git repositories",
              IsKnown = false
            },
            ActiveContract = new Contract
            {
              StartDate = DateTimeOffset.UtcNow.AddYears(-100),
              EndDate = DateTimeOffset.UtcNow.AddYears(1000)
            },
            Pets = new List<Pet>()
            {
              new Pet{
                Name = "George",
                Age = 55,
                Favorite = false
              },
              new Pet{
                Name = "Barry",
                Age = 22,
                Favorite = true
              }
            }
          };
          context.Add(kevin);
          context.SaveChanges();
        }
        catch (Exception ex)
        {
          var logger = services.GetRequiredService<ILogger<Program>>();
          logger.LogError(ex, "An error occurred creating the DB.");
        }
      }
    }
  }
}
