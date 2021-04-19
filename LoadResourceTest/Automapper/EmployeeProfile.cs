using System.Linq;
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
      bool favoritePet = false;
      bool includeSecrets = false;

      CreateMap<Employee, EmployeeDto>()
        .ForMember(x => x.Secret, opt => opt.MapFrom(x => includeSecrets ? x.Secret : null))
        .ForMember(x => x.ActiveContract, opt => opt.MapFrom(x => includeContract ? x.ActiveContract : null))
        .ForMember(x => x.FavoritePet, opt => opt.MapFrom(x =>
        favoritePet ?
          x.Pets.First(c => c.Favorite)
          : null
        ));
    }
  }
}
