using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Amazon;
using Amazon.S3;
using Amazon.S3.Transfer;
using Microsoft.AspNetCore.Http;
using vehicly.DAO;
using vehicly.Models;

namespace vehicly.Repositories;

public class VehiclesRepository : IVehiclesRepository
{
  private readonly VehiclesContext _context;

  public VehiclesRepository(VehiclesContext context)
  {
    _context = context;
  }

  public Vehicle GetVehicleById(Guid id)
  {
    return _context.Vehicles.FirstOrDefault(vehicle => vehicle.Id == id);
  }

  public void DeleteVehicle(Vehicle vehicle)
  {
    _context.Vehicles.Remove(vehicle);
  }

  public IEnumerable<Vehicle> GetVehicles()
  {
    return _context.Vehicles.ToList();
  }

  public void AddVehicle(Vehicle vehicle)
  {
    if (vehicle == null) throw new ArgumentNullException(nameof(vehicle));
    _context.Vehicles.Add(vehicle);
  }

  public void UpdateVehicle(Vehicle vehicle)
  {
    vehicle.UpdatedAt = DateTime.UtcNow;
    _context.Vehicles.Update(vehicle);
  }

  public bool SaveChanges()
  {
    return _context.SaveChanges() >= 0;
  }

  public async Task<string> UploadFileToS3(IFormFile file)
  {
    var accessKeyID = AppData.Configuration["AWS:AccessKeyID"];
    var secretAccessKey = AppData.Configuration["AWS:SecretAccessKey"];
    var bucket = AppData.Configuration["AWS:DefaultBucket"];
    var region = RegionEndpoint.EUWest3;
    var stream = new MemoryStream();
    //var key = $"vStore/{Path.GetRandomFileName()}.jpg";
    var key = $"vStore/{Guid.NewGuid()}.jpg";
    //var cannedACL = S3CannedACL.BucketOwnerFullControl;
    var cannedACL = S3CannedACL.PublicRead;
    var client = new AmazonS3Client(accessKeyID, secretAccessKey, region);

    try
    {
      file.CopyTo(stream);
      var uploadRequest = new TransferUtilityUploadRequest
      {
        InputStream = stream,
        Key = key,
        ContentType = "image/jpg",
        BucketName = bucket,
        CannedACL = cannedACL
      };
      var transferUtility = new TransferUtility(client);
      await transferUtility.UploadAsync(uploadRequest);

      return $"https://{bucket}.s3.amazonaws.com/{key}";
    }
    catch (Exception e)
    {
      Console.WriteLine($"Error uploading file to S3: {e}");
      ;
      return null;
    }
  }
}