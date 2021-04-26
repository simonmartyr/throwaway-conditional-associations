using System;
using System.Collections.Generic;
using LoadResourceTest.Controllers;
using LoadResourceTest.Entities;
using LoadResourceTest.GenericResolver;
using Microsoft.Extensions.Options;
using Xunit;

namespace LoadResourceTest.UnitTests.GenericResolver
{
  public class IncludeResolverTests
  {
    [Fact]
    public void CanFindAttribute()
    {
      //Given
      var includes = new IncludeResolver<MockDtoIncludes>(new GenericIncludeResolverOptions());
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
      var includes = new IncludeResolver<MockDtoIncludes>(new GenericIncludeResolverOptions());
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
      var includes = new IncludeResolver<MockDtoIncludes>(new GenericIncludeResolverOptions());
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
      var includes = new IncludeResolver<MockDtoIncludes>(new GenericIncludeResolverOptions());
      //When
      //Then
      Assert.Throws<NullReferenceException>(() => includes.Resolve(null));
    }

    [Fact]
    public void ResolverNoAttributes()
    {
      //Given
      var includes = new IncludeResolver<MockDtoNoIncludes>(new GenericIncludeResolverOptions());
      var toFind = new string[] { };
      //When
      var result = includes.Resolve(toFind);
      //Then
      Assert.Empty(result);
    }

     [Fact]
    public void ResolverIgnoresCaseByDefault()
    {
      //Given
      var includes = new IncludeResolver<MockDtoIncludes>(new GenericIncludeResolverOptions());
      var toFind = new string[] { "tofind" };
      //When
      var result = includes.Resolve(toFind);
      //Then
      Assert.NotEmpty(result);
    }

    [Fact]
    public void ResolverEvaluatesCaseWhenConfigured()
    {
      //Given
      var includes = new IncludeResolver<MockDtoIncludes>(new GenericIncludeResolverOptions(caseSensitive: true));
      var toFind = new string[] { "tofind" };
      //When
      var result = includes.Resolve(toFind);
      //Then
      Assert.Empty(result);
    }

    [Fact]
    public void ResolverThrowsErrorsWhenConfigured()
    {
      //Given
      var includes = new IncludeResolver<MockDtoIncludes>(new GenericIncludeResolverOptions(throwErrors: true));
      var toFind = new string[] { nameof(MockDtoIncludes.Name) };
      //When
      //Then
      Assert.Throws<KeyNotFoundException>(() => includes.Resolve(toFind));
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

  public class GenericIncludeResolverOptions : IOptions<IncludeResolverOptions>
  {
    public IncludeResolverOptions Value { get; }
    public GenericIncludeResolverOptions(bool caseSensitive = false, bool throwErrors = false)
    {
      Value = new IncludeResolverOptions()
      {
        CaseSensitive = caseSensitive,
        ThrowExceptions = throwErrors
      };
    }
  }
}
