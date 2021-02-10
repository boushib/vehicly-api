using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace vehiclesStoreAPI.Models
{
  public class User
  {
    [Key]
    [JsonPropertyName("id")]
    public Guid Id { get; set; }
    [Required]
    [JsonPropertyName("username")]
    public string Username { get; set; }
    [Required]
    [JsonPropertyName("password")]
    public string Password { get; set; }
    [JsonPropertyName("roles")]
    public List<string> Roles { get; set; } = new List<string>() { "user" };
  }
}