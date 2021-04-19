using System.Linq;
using AutoMapper;
using LoadResourceTest.DTOs;
using LoadResourceTest.Entities;

namespace LoadResourceTest.Automapper
{
  public class PetProfile : Profile
  {
    public PetProfile()
    {
      CreateMap<Pet, PetDto>();
    }
  }
}
