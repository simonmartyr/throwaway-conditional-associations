using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using LoadResourceTest.Database;
using LoadResourceTest.DTOs;
using LoadResourceTest.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace LoadResourceTest.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class EmployeeController : ControllerBase
  {
    private readonly ILogger<EmployeeController> _logger;
    private readonly EmployeeContext _dbContext;

    public EmployeeController(ILogger<EmployeeController> logger, EmployeeContext dbContext)
    {
      _logger = logger;
      _dbContext = dbContext;
    }

    [HttpGet("{id}")]
    public async Task<EmployeeDto> GetAgent(int id, [FromQuery] Includer includer, CancellationToken cancellationToken = default)
    {
      var includes = includer.GetIncludesParsed();

      var includeContract = includes.Contains(nameof(Employee.ActiveContract));
      //agent has permission to view this
      var includeSecrets = includes.Contains(nameof(Employee.Secret));
      var baseQuery = _dbContext.Employees
      .Select(x => new EmployeeDto()
      {
        Id = x.Id,
        Name = x.Name,
        Secret = includeSecrets ? new SecretDto()
        {
          Secret = x.Secret.Secret,
          IsKnown = x.Secret.IsKnown
        } : null,
        ActiveContract = includeContract ? new ContractDto()
        {
          StartDate = x.ActiveContract.StartDate
        } : null,
      });

      return await baseQuery.FirstAsync(x => x.Id == id);
    }

  }
}
