using Microsoft.EntityFrameworkCore;
using vehicly.Models;

namespace vehicly.DAO;

public class VehiclesContext : DbContext
{
  // base() calls the DbContext constructor
  public VehiclesContext(DbContextOptions<VehiclesContext> options) : base(options)
  {
    //
  }

  // create a representation of the Vehicles model in our db
  public DbSet<Vehicle> Vehicles { get; set; }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.HasPostgresExtension("uuid-ossp");
    base.OnModelCreating(modelBuilder);
  }
}