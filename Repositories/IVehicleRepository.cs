using System;
using System.Collections.Generic;
using vehiclesStoreAPI.Models;

namespace vehiclesStoreAPI.Repositories
{
  // use in shortcut to create interface
  public interface IVehicleRepository
  {
    IEnumerable<Vehicle> GetVehicles();
    Vehicle GetVehicleById(Guid id);
    void AddVehicle(Vehicle vehicle);
    bool SaveChanges();
  }
}