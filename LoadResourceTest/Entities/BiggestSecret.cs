using System;

namespace LoadResourceTest.Entities
{
  public class BiggestSecret
  {
    public int Id { get; set; }
    public string Secret { get; set; }
    public bool IsKnown { get; set; }
    public Employee Employee { get; set; }
    public int EmployeeId { get; set; }
  }
}
