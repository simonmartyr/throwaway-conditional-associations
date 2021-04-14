using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LoadResourceTest.Database
{
  public static class DatabaseStartup
  {
    public static IServiceCollection ConfigureEmployeeDatabase(this IServiceCollection services, IConfiguration configuration)
    {
      return ConfigureEmployeeDatabaseSqlServer(services, configuration);
    }

    private static IServiceCollection ConfigureEmployeeDatabaseSqlServer(this IServiceCollection services, IConfiguration configuration)
    {
      return services
        .AddDbContextPool<EmployeeContext>(options =>
          options.UseSqlServer(configuration.GetConnectionString("EmployeeContext"),
            sqlOptions => sqlOptions.EnableRetryOnFailure(10, TimeSpan.FromSeconds(30), null)));
    }
  }
}