using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using LoadResourceTest.Database;
using LoadResourceTest.DTOs;
using LoadResourceTest.Entities;
using LoadResourceTest.GenericResolver;
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
    private readonly IMapper _mapper;
    private readonly IIncludeResolver<EmployeeDto> _resolver;

    public EmployeeController(ILogger<EmployeeController> logger, EmployeeContext dbContext, IMapper mapper, IIncludeResolver<EmployeeDto> resolver)
    {
      _logger = logger;
      _dbContext = dbContext;
      _mapper = mapper;
      _resolver = resolver;
    }

    [HttpPost("{id}")]
    public async Task<EmployeeDto> GetAgent(int id, [FromQuery] Includer includer, CancellationToken cancellationToken = default)
    {
      var includes = includer.IncludesArray;
      var toInclude = _resolver.Resolve(includes);
      var baseQuery = _dbContext.Employees
      .ProjectTo<EmployeeDto>(_mapper.ConfigurationProvider, null, toInclude.ToArray());
      return await baseQuery.FirstAsync(x => x.Id == id);
    }
  }
}
