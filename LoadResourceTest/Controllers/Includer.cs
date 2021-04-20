using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace LoadResourceTest.Controllers
{
  public class Includer
  {
    [DataMember]
    public string Includes { get; set; } = "";
    private List<string> ParsedIncludes { get; set; }
    public List<string> GetIncludesParsed()
    {
      return Includes.Split(",", System.StringSplitOptions.RemoveEmptyEntries).Select(t => t.Trim()).ToList();
    }
    public bool IncludesContains(string term)
    {
      return GetIncludesParsed().Contains(term.ToUpper());
    }
  }
}