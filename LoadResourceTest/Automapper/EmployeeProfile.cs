using System.Linq;
using AutoMapper;
using LoadResourceTest.DTOs;
using LoadResourceTest.Entities;
using Microsoft.Extensions.Logging;

namespace LoadResourceTest.Automapper
{
  public class EmployeeProfile : Profile
  {
    public EmployeeProfile()
    {
      CreateMap<Employee, EmployeeDto>()
      .ForMember(x => x.ActiveContract, opt => opt.ExplicitExpansion())
      .ForMember(x => x.Secret, opt => opt.ExplicitExpansion())
      .ForMember(x => x.FavoritePet, opt => opt.ExplicitExpansion())
      .ForMember(x => x.FavoritePet, opt => opt.MapFrom(x => x.Pets.First(j => j.Favorite)));
    }
  }

  public static class AutomapperStatics
  {
    public static BiggestSecret Thing = new BiggestSecret();
  }
}
