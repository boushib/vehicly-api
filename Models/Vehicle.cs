// id, make, model, fuel, year, price
using System.ComponentModel.DataAnnotations;

namespace vehiclesStoreAPI.Models
{
  public class Vehicle
  {
    // use prop shortcut to create a new property
    [Key]
    public string Id { get; set; }
    [Required]
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