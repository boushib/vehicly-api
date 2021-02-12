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

    [JsonPropertyName("image_url")]
    public string ImageURL { get; set; }

    [JsonPropertyName("location")]
    public string Location { get; set; }

    [JsonPropertyName("year")]
    public int Year { get; set; }

    [JsonPropertyName("price")]
    public int Price { get; set; }

    [JsonPropertyName("created_at")]
    public DateTime CreatedAt { get; set; }
  }
}