using Microsoft.EntityFrameworkCore;
using vehiclesStoreAPI.Models;

namespace vehiclesStoreAPI.DAO
{
  public class UsersContext : DbContext
  {
    public UsersContext(DbContextOptions<UsersContext> options) : base(options)
    {
      //
    }

    public DbSet<User> Users { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.HasPostgresExtension("uuid-ossp");
      base.OnModelCreating(modelBuilder);
    }
  }
}