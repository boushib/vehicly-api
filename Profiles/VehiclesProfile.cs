using AutoMapper;
using vehicly.DTO;
using vehicly.Models;

namespace vehicly.Profiles;

public class VehiclesProfile : Profile
{
  public VehiclesProfile()
  {
    CreateMap<Vehicle, VehicleDTO>();
  }
}