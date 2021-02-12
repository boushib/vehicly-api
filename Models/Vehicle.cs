using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace vehiclesStoreAPI.Models
{
  public class Vehicle
  {
    // use prop shortcut to create a new property
    [Key]
    public Guid Id { get; set; }

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

    [Required]
    public string ImageURL { get; set; }

    [Required]
    public string Location { get; set; }

    [Required]
    public string Phone { get; set; }

    [Required]
    public int Horsepower { get; set; }

    [Required]
    public string GearBox { get; set; }

    // TODO: add this later
    // mileage -> int
    // description: text
    // username,

    [Required]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public DateTime? UpdatedAt { get; set; }
  }
}