using System.Collections.Generic;

namespace LoadResourceTest.Entities
{
  public class Employee
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public Contract ActiveContract { get; set; }
    public BiggestSecret Secret { get; set; }
  }
}
