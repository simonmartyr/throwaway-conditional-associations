using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.Extensions.Options;

namespace LoadResourceTest.GenericResolver
{
  public class IncludeResolver<T> : IIncludeResolver<T>
  {
    private readonly Dictionary<string, Expression<Func<T, object>>> Includes;
    private readonly IOptions<IncludeResolverOptions> _options;
    public IncludeResolver(IOptions<IncludeResolverOptions> options)
    {
      _options = options;
      Includes = CreateIncludeDictionary();
    }

    public List<Expression<Func<T, object>>> Resolve(string[] list)
    {
      var toReturn = new List<Expression<Func<T, object>>>();
      foreach (var i in list)
      {
        var hasKey = Includes.TryGetValue(i, out var expression);
        if (hasKey)
          toReturn.Add(expression);
        else if (_options.Value.ThrowExceptions)
          throw new KeyNotFoundException();
      }
      return toReturn;
    }

    private Dictionary<string, Expression<Func<T, object>>> CreateIncludeDictionary()
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
      }, 
       _options.Value.CaseSensitive ? StringComparer.CurrentCulture : StringComparer.OrdinalIgnoreCase);
    }
  }
}
