using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace LoadResourceTest.Controllers
{
  public class Includer
  {
    [DataMember]
    public string Includes { get; set; } = "";
    public List<string> GetIncludesParsed() =>
      Includes.Split(",", System.StringSplitOptions.RemoveEmptyEntries).Select(t => t.Trim()).ToList();
  }
}