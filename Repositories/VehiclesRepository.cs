using System.Collections.Generic;
using vehiclesStoreAPI.Models;
using vehiclesStoreAPI.DAO;
using System.Linq;
using System;

namespace vehiclesStoreAPI.Repositories
{
  public class VehiclesRepository : IVehiclesRepository
  {
    private readonly VehiclesContext _context;

    public VehiclesRepository(VehiclesContext context)
    {
      _context = context;
    }

    public Vehicle GetVehicleById(Guid id)
    {
      return _context.Vehicles.FirstOrDefault(vehicle => vehicle.Id == id);
    }

    public IEnumerable<Vehicle> GetVehicles()
    {
      return _context.Vehicles.ToList();
    }

    public void AddVehicle(Vehicle vehicle)
    {
      if (vehicle == null) throw new ArgumentNullException(nameof(vehicle));
      _context.Vehicles.Add(vehicle);
    }

    public bool SaveChanges()
    {
      return _context.SaveChanges() >= 0;
    }
  }
}