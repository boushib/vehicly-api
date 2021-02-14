using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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
    private readonly IVehiclesRepository _repository;
    private readonly IMapper _mapper;

    // use stor shortcut to create a constructor.
    public VehiclesController(IVehiclesRepository repository, IMapper mapper)
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

    [HttpDelete("{id}")]
    [Authorize]
    public ActionResult DeleteVehicle(Guid id)
    {
      var vehicle = _repository.GetVehicleById(id);
      if (vehicle == null) return NotFound();
      _repository.DeleteVehicle(vehicle);
      _repository.SaveChanges();
      return Ok(_mapper.Map<VehicleDTO>(vehicle));
    }

    [HttpPost]
    [Authorize]
    public ActionResult<VehicleDTO> AddVehicle(Vehicle vehicle)
    {
      _repository.AddVehicle(vehicle);
      _repository.SaveChanges();
      // TODO: return a 201 status code instead of 200
      return Ok(_mapper.Map<VehicleDTO>(vehicle));
    }

    [HttpPut("{id}")]
    [Authorize]
    public ActionResult<VehicleDTO> UpdateVehicle(Guid id, Vehicle vehicle)
    {
      //var existingVehicle = _repository.GetVehicleById(id);
      //if (existingVehicle == null) return NotFound();
      vehicle.Id = id;
      _repository.UpdateVehicle(vehicle);
      _repository.SaveChanges();
      return Ok(_mapper.Map<VehicleDTO>(vehicle));
    }

    [HttpPost("upload")]
    [Authorize]
    public async Task<ActionResult> UploadFileToS3(IFormFile file)
    {
      var fileURL = await _repository.UploadFileToS3(file);
      //if (fileURL == null) return BadRequest();
      return Ok(fileURL);
    }
  }
}