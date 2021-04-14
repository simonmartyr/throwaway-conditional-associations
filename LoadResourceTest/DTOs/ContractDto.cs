using System;

namespace LoadResourceTest.DTOs
{
  public class ContractDto
  {
    public int Id { get; set; }
    public DateTimeOffset StartDate { get; set; }
    public DateTimeOffset EndDate { get; set; }
  }
}
