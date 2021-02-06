using Microsoft.EntityFrameworkCore;
using vehiclesStoreAPI.Models;

namespace vehiclesStoreAPI.DAO
{
  public class VehiclesContext : DbContext
  {
    // base() calls the DbContext constructor
    public VehiclesContext(DbContextOptions<VehiclesContext> options) : base(options)
    {

    }

    // create a representation of the Vehicles model in our db
    public DbSet<Vehicle> Vehicles { get; set; }
  }
}