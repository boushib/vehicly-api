using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using vehiclesStoreAPI.Models;
using vehiclesStoreAPI.Repositories;

namespace vehiclesStoreAPI.Controllers
{
  //[Route("/api/[controller]")]
  [Route("/api/v1/vehicles")]
  [ApiController] // class decorator
  public class VehiclesController : ControllerBase
  {
    private readonly IVehicleRepository _repository;

    // use stor shortcut to create a constructor.
    public VehiclesController(IVehicleRepository repository)
    {
      _repository = repository;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Vehicle>> GetVehicles()
    {
      return Ok(_repository.GetVehicles());
    }

    [HttpGet("{id}")]
    public ActionResult<Vehicle> GetVehicleById(string id)
    {
      var vehicle = _repository.GetVehicleById(id);
      return vehicle == null ? NotFound() : Ok(vehicle);
    }
  }
}