using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using vehiclesStoreAPI.Models;

namespace vehiclesStoreAPI.Repositories
{
  // use in shortcut to create interface
  public interface IVehiclesRepository
  {
    IEnumerable<Vehicle> GetVehicles();
    Vehicle GetVehicleById(Guid id);
    void DeleteVehicle(Vehicle vehicle);
    void AddVehicle(Vehicle vehicle);
    Task<string> UploadFileToS3(IFormFile file);
    bool SaveChanges();
  }
}