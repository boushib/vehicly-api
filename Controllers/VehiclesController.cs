using System;
using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using vehiclesStoreAPI.DTO;
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
    private readonly IMapper _mapper;

    // use stor shortcut to create a constructor.
    public VehiclesController(IVehicleRepository repository, IMapper mapper)
    {
      _repository = repository;
      _mapper = mapper;
    }

    [HttpGet]
    public ActionResult<IEnumerable<VehicleDTO>> GetVehicles()
    {
      return Ok(_mapper.Map<IEnumerable<VehicleDTO>>(_repository.GetVehicles()));
    }

    [HttpGet("{id}")]
    public ActionResult<VehicleDTO> GetVehicleById(Guid id)
    {
      var vehicle = _repository.GetVehicleById(id);
      return vehicle == null ? NotFound() : Ok(_mapper.Map<VehicleDTO>(vehicle));
    }

    [HttpPost]
    //[Authorize]
    public ActionResult<VehicleDTO> AddVehicle(Vehicle vehicle)
    {
      _repository.AddVehicle(vehicle);
      _repository.SaveChanges();
      // TODO: return a 201 status code instead of 200
      return Ok(_mapper.Map<VehicleDTO>(vehicle));
    }
  }
}