using System.Collections.Generic;
using vehiclesStoreAPI.Models;
using vehiclesStoreAPI.DAO;
using System.Linq;

namespace vehiclesStoreAPI.Repositories
{
  public class VehicleRepository : IVehicleRepository
  {
    private readonly VehiclesContext _context;

    public VehicleRepository(VehiclesContext context)
    {
      _context = context;
    }

    public Vehicle GetVehicleById(string id)
    {
      return _context.Vehicles.FirstOrDefault(vehicle => vehicle.Id == id);
    }

    public IEnumerable<Vehicle> GetVehicles()
    {
      return _context.Vehicles.ToList();
    }
  }
}