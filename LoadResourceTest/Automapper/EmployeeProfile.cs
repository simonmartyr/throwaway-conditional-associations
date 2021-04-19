using AutoMapper;
using LoadResourceTest.DTOs;
using LoadResourceTest.Entities;

namespace LoadResourceTest.Automapper
{
  public class EmployeeProfile : Profile
  {
    public EmployeeProfile()
    {
      bool includeContract = false;
      CreateMap<Employee, EmployeeDto>()
      .ConvertUsing(x => new EmployeeDto
      {
        Id = x.Id,
        Name = x.Name,
        ActiveContract = includeContract ? new ContractDto()
        {
          StartDate = x.ActiveContract.StartDate
        } : null,
      });
    }
  }
}
