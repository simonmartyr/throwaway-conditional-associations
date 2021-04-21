using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace LoadResourceTest.GenericResolver
{
  public class IncludeResolver<T> : IIncludeResolver<T>
  {
    private readonly Dictionary<string, Expression<Func<T, object>>> Includes;
    public IncludeResolver()
    {
      Includes = getAttrs();
    }

    public List<Expression<Func<T, object>>> resolve(string[] list)
    {
      var toReturn = new List<Expression<Func<T, object>>>();
      foreach (var i in list)
      {
        var hasKey = Includes.TryGetValue(i, out var expression);
        if (hasKey)
          toReturn.Add(expression);
      }
      return toReturn;
    }

    private Dictionary<string, Expression<Func<T, object>>> getAttrs()
    {
      var parameter = Expression.Parameter(typeof(T));
      return typeof(T)
      .GetProperties()
      .Where(p => ConditionalInclude.IsDefined(p, typeof(ConditionalInclude)))
      .ToDictionary(x => x.Name, x =>
      {
        var property = Expression.Property(parameter, x);
        var conversion = Expression.Convert(property, typeof(object));
        return Expression.Lambda<Func<T, object>>(conversion, parameter);
      }, StringComparer.OrdinalIgnoreCase);
    }
  }
}
