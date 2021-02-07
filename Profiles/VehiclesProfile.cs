
using AutoMapper;
using vehiclesStoreAPI.Models;
using vehiclesStoreAPI.DTO;

namespace vehiclesStoreAPI.Profiles
{
  public class VehiclesProfile : Profile
  {
    public VehiclesProfile()
    {
      CreateMap<Vehicle, VehicleDTO>();
    }
  }
}