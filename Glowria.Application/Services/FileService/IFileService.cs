using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Glowria.Application.Services.FileService;

public interface IFileService
{
    Task<string> UploadFile(IFormFile file);
    Task<IActionResult> DeleteFileAsync(string fileUrl);
}