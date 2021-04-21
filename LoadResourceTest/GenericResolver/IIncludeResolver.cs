using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace LoadResourceTest.GenericResolver
{
  public interface IIncludeResolver<T>
  {
    List<Expression<Func<T, object>>> Resolve(string[] list);
  }
}