using System.Collections.Generic;
using vehiclesStoreAPI.Models;

namespace vehiclesStoreAPI.Repositories
{
  public class VehicleRepository : IVehicleRepository
  {
    public Vehicle GetVehicleById(string id)
    {
      return new Vehicle { Id = "c-1", Make = "Audi", Model = "Q5", Fuel = "Gasoil", Year = 2017, Price = 240000 };
    }

    public IEnumerable<Vehicle> GetVehicles()
    {
      return new List<Vehicle>{
        new Vehicle { Id = "c-1", Make = "Audi", Model = "Q5", Fuel = "Gasoil", Year = 2017, Price = 240000 },
        new Vehicle { Id = "c-2", Make = "Audi", Model = "Q6", Fuel = "Gasoil", Year = 2018, Price = 290000 },
        new Vehicle { Id = "c-3", Make = "Audi", Model = "Q7", Fuel = "Gasoil", Year = 2019, Price = 340000 },
      };
    }
  }
}