using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace LoadResourceTest.Controllers
{
  public class Includer
  {
    public string[] IncludesArray { get; private set; } = new string[0];
    private string _includes = "";
    [DataMember]
    public string Includes
    {
      get
      {
        return _includes;
      }
      set
      {
        _includes = value;
        IncludesArray = Parse();
      }
    }
    private string[] Parse() =>
    _includes?.Split(",", System.StringSplitOptions.RemoveEmptyEntries)?.Select(t => t.Trim())?.ToArray() ?? new string[0];
  }
}