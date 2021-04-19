using System.Linq;
using AutoMapper;
using LoadResourceTest.DTOs;
using LoadResourceTest.Entities;

namespace LoadResourceTest.Automapper
{
  public class ContractProfile : Profile
  {
    public ContractProfile()
    {
      CreateMap<Contract, ContractDto>();
    }
  }
}
