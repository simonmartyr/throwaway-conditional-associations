using System.Linq;
using AutoMapper;
using LoadResourceTest.DTOs;
using LoadResourceTest.Entities;

namespace LoadResourceTest.Automapper
{
  public class SecretProfile : Profile
  {
    public SecretProfile()
    {
      CreateMap<BiggestSecret, SecretDto>();
    }
  }
}
