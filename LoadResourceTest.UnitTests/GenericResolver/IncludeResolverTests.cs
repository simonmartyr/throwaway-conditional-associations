using System;
using LoadResourceTest.Controllers;
using LoadResourceTest.Entities;
using LoadResourceTest.GenericResolver;
using Xunit;

namespace LoadResourceTest.UnitTests.GenericResolver
{
  public class IncludeResolverTests
  {
    [Fact]
    public void CanFindAttribute()
    {
      //Given
      var includes = new IncludeResolver<MockDtoIncludes>();
      var toFind = new string[] { nameof(MockDtoIncludes.ToFind) };
      //When
      var result = includes.Resolve(toFind);
      //Then
      Assert.NotEmpty(result);
    }

    [Fact]
    public void ResolverReturnsEmptyArrayWhenNotFound()
    {
      //Given
      var includes = new IncludeResolver<MockDtoIncludes>();
      var toFind = new string[] { nameof(MockDtoIncludes.Name) };
      //When
      var result = includes.Resolve(toFind);
      //Then
      Assert.Empty(result);
    }

    [Fact]
    public void ResolverReturnsEmptyArrayWhenNotFoundEmptyList()
    {
      //Given
      var includes = new IncludeResolver<MockDtoIncludes>();
      var toFind = new string[] { };
      //When
      var result = includes.Resolve(toFind);
      //Then
      Assert.Empty(result);
    }

    [Fact]
    public void ResolverReturnsEmptyArrayWhenNotFoundNull()
    {
      //Given
      var includes = new IncludeResolver<MockDtoIncludes>();
      //When
      //Then
      Assert.Throws<NullReferenceException>(() => includes.Resolve(null));
    }

    [Fact]
    public void ResolverNoAttributes()
    {
      //Given
      var includes = new IncludeResolver<MockDtoNoIncludes>();
      var toFind = new string[] { };
      //When
      var result = includes.Resolve(toFind);
      //Then
      Assert.Empty(result);
    }
  }

  public class MockDtoNoIncludes
  {
    public string Name { get; set; }
  }

  public class MockDtoIncludes
  {
    public string Name { get; set; }
    [ConditionalInclude]
    public string ToFind { get; set; }
  }
}
