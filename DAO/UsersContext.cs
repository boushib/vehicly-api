using Microsoft.EntityFrameworkCore;
using vehicly.Models;

namespace vehicly.DAO;

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