using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace vehiclesStoreAPI.DTO
{
  public class UserDTO
  {
    [JsonPropertyName("id")]
    public Guid Id { get; set; }
    [JsonPropertyName("username")]
    public string Username { get; set; }
    [JsonPropertyName("roles")]
    public List<string> Roles { get; set; } = new List<string>() { "user" };
  }
}