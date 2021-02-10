using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace vehiclesStoreAPI.Models
{
  public class Vehicle
  {
    // use prop shortcut to create a new property
    [Key]
    [JsonPropertyName("id")]
    public Guid Id { get; set; }
    [JsonPropertyName("model")]
    public string Make { get; set; }
    [Required]
    [JsonPropertyName("model")]
    public string Model { get; set; }
    [Required]
    [JsonPropertyName("fuel")]
    public string Fuel { get; set; }
    [Required]
    [JsonPropertyName("year")]
    public int Year { get; set; }
    [Required]
    [JsonPropertyName("createdAt")]
    public int Price { get; set; }
    [Required]
    [JsonPropertyName("createdAt")]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    [JsonPropertyName("updatedAt")]
    public DateTime? UpdatedAt { get; set; }
  }
}