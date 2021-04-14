using System;
using LoadResourceTest.Controllers;
using LoadResourceTest.Entities;
using Xunit;

namespace LoadResourceTest.UnitTests.Controllers
{
  public class IncluderTests
  {
    [Fact]
    public void GetIncludesParsed()
    {
      var includer = new Includer();
      var secret = nameof(Employee.Secret);
      var contract = nameof(Employee.ActiveContract);
      string[] includes = { secret, contract };
      includer.Includes = string.Join(",", includes);
      var result = includer.GetIncludesParsed();

      Assert.NotEmpty(result);
      Assert.Contains(secret, result);
      Assert.Contains(contract, result);
    }

    [Fact]
    public void GetIncludesParsedReturnsEmpty()
    {
      var includer = new Includer();
      var result = includer.GetIncludesParsed();
      Assert.Empty(result);
    }
  }
}
