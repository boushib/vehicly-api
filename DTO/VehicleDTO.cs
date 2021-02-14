using System;
using System.Text.Json.Serialization;

namespace vehiclesStoreAPI.DTO
{
  // this is basically the model exposed to the end user.
  public class VehicleDTO
  {
    // use prop shortcut to create a new property
    [JsonPropertyName("id")]
    public string Id { get; set; }

    [JsonPropertyName("make")]
    public string Make { get; set; }

    [JsonPropertyName("model")]
    public string Model { get; set; }

    [JsonPropertyName("fuel")]
    public string Fuel { get; set; }

    [JsonPropertyName("imageURL")]
    public string ImageURL { get; set; }

    [JsonPropertyName("location")]
    public string Location { get; set; }

    [JsonPropertyName("year")]
    public int Year { get; set; }

    [JsonPropertyName("price")]
    public int Price { get; set; }

    [JsonPropertyName("phone")]
    public string Phone { get; set; }

    [JsonPropertyName("horsepower")]
    public int Horsepower { get; set; }

    [JsonPropertyName("gearBox")]
    public string GearBox { get; set; }

    [JsonPropertyName("createdAt")]
    public DateTime CreatedAt { get; set; }

    [JsonPropertyName("updatedAt")]
    public DateTime? UpdatedAt { get; set; }
  }
}