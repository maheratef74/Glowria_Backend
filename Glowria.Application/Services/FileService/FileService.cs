using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Glowria.Application.Services.FileService;

public class FileService : IFileService
{
    private readonly IWebHostEnvironment _webHostEnvironment;

    public FileService(IWebHostEnvironment webHostEnvironment)
    {
        _webHostEnvironment = webHostEnvironment;
    }

    public async Task<string> UploadFile(IFormFile file)
    {
        var fakeFileName = Path.GetRandomFileName();
       
        var path = Path.Combine(_webHostEnvironment.ContentRootPath, "Uploads", fakeFileName);

        using FileStream fileStream = new(path, FileMode.Create);

        await file.CopyToAsync(fileStream);
        return fakeFileName;
    }

    public async Task<IActionResult> DeleteFileAsync(string fileUrl)
    {
        var uploadsFolder = Path.Combine(_webHostEnvironment.ContentRootPath, "Uploads");
        var filePath = Path.Combine(uploadsFolder, fileUrl);
        if (!System.IO.File.Exists(filePath))
        {
            return new NotFoundResult();
        }
        try
        {
            System.IO.File.Delete(filePath);
            return new OkResult();
        }
        catch (Exception ex)
        {
            return new StatusCodeResult(StatusCodes.Status500InternalServerError);
        }
    }
}