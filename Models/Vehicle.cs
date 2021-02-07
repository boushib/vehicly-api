using System;
using System.ComponentModel.DataAnnotations;

namespace vehiclesStoreAPI.Models
{
  public class Vehicle
  {
    // use prop shortcut to create a new property
    [Key]
    public Guid Id { get; set; }
    [Required]

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }
    public string Make { get; set; }
    [Required]
    public string Model { get; set; }
    [Required]
    public string Fuel { get; set; }
    [Required]
    public int Year { get; set; }
    [Required]
    public int Price { get; set; }
  }
}