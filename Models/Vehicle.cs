// id, make, model, fuel, year, price
namespace vehiclesStoreAPI.Models
{
  public class Vehicle
  {
    // use prop shortcut to create a new property
    public string Id { get; set; }
    public string Make { get; set; }
    public string Model { get; set; }
    public string Fuel { get; set; }
    public int Year { get; set; }
    public int Price { get; set; }
  }
}