using System.Collections.Generic;

namespace LoadResourceTest.Entities
{
  public class Pet
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public bool Favorite { get; set; }
    public Employee Employee { get; set; }
    public int EmployeeId { get; set; }
  }
}
