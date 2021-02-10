using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace vehiclesStoreAPI.Models
{
  public class User
  {
    [Key]
    public Guid Id { get; set; }
    [Required]
    public string Username { get; set; }
    [Required]
    public string Password { get; set; }
    public List<string> Roles { get; set; } = new List<string>() { "user" };
  }
}