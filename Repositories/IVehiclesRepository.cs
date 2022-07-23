using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using vehicly.Models;

namespace vehicly.Repositories;

// use in shortcut to create interface
public interface IVehiclesRepository
{
  IEnumerable<Vehicle> GetVehicles();
  Vehicle GetVehicleById(Guid id);
  void DeleteVehicle(Vehicle vehicle);
  void AddVehicle(Vehicle vehicle);
  void UpdateVehicle(Vehicle vehicle);
  Task<string> UploadFileToS3(IFormFile file);
  bool SaveChanges();
}