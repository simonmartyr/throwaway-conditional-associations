using System.Collections.Generic;

namespace LoadResourceTest.DTOs
{
  public class EmployeeDto
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public ContractDto ActiveContract { get; set; }
    public SecretDto Secret { get; set; }
  }
}
