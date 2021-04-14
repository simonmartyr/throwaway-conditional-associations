using System;

namespace LoadResourceTest.Entities
{
  public class Contract
  {
    public int Id { get; set; }
    public DateTimeOffset StartDate { get; set; }
    public DateTimeOffset EndDate { get; set; }
    public Employee Employee { get; set; }
    public int EmployeeId { get; set; }
  }
}
