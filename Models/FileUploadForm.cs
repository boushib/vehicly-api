using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace vehicly.Models;

public class FileUploadForm
{
  [Required] public IFormFile File { get; set; }
}