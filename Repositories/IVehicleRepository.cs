using System.Collections.Generic;
using vehiclesStoreAPI.Models;

namespace vehiclesStoreAPI.Repositories
{
  // use in shortcut to create interface
  public interface IVehicleRepository
  {
    IEnumerable<Vehicle> GetVehicles();
    Vehicle GetVehicleById(string id);
  }
}