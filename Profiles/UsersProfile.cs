
using AutoMapper;
using vehiclesStoreAPI.Models;
using vehiclesStoreAPI.DTO;

namespace vehiclesStoreAPI.Profiles
{
  public class UsersProfile : Profile
  {
    public UsersProfile()
    {
      CreateMap<User, UserDTO>();
    }
  }
}