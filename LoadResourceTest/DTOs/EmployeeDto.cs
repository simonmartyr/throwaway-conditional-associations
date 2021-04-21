using System;
using System.Collections.Generic;
using LoadResourceTest.Entities;
using LoadResourceTest.GenericResolver;

namespace LoadResourceTest.DTOs
{
  public class EmployeeDto
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    [ConditionalInclude]
    public ContractDto ActiveContract { get; set; }
    [ConditionalInclude]
    public SecretDto Secret { get; set; }
    [ConditionalInclude]
    public PetDto FavoritePet { get; set; }
  }
}
