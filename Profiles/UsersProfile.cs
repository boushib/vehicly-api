using AutoMapper;
using vehicly.DTO;
using vehicly.Models;

namespace vehicly.Profiles;

public class UsersProfile : Profile
{
  public UsersProfile()
  {
    CreateMap<User, UserDTO>();
  }
}