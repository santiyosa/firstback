using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class ImagesController : ControllerBase
{
    private readonly string _uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "uploads");

    [HttpPost]
    public async Task<IActionResult> UploadImage(IFormFile file)
    {
        if (file == null || file.Length == 0)
            return BadRequest("No se subió ningún archivo");

        var fileName = $"{Guid.NewGuid()}_{Path.GetFileName(file.FileName)}";
        var path = Path.Combine(_uploadsFolder, fileName);

        Directory.CreateDirectory(_uploadsFolder); // crea si no existe

        using (var stream = new FileStream(path, FileMode.Create))
        {
            await file.CopyToAsync(stream);
        }

        var url = $"{Request.Scheme}://{Request.Host}/api/images/{fileName}";
        return Ok(new { fileName, url });
    }

    [HttpGet]
    public IActionResult GetAllImages()
    {
        if (!Directory.Exists(_uploadsFolder))
            return NotFound("El directorio de imágenes no existe.");

        var files = Directory.GetFiles(_uploadsFolder)
                             .Select(filePath => new
                             {
                                 FileName = Path.GetFileName(filePath),
                                 Url = $"{Request.Scheme}://{Request.Host}/api/images/{Path.GetFileName(filePath)}"
                             })
                             .ToList();

        return Ok(files);
    }

    [HttpGet("{fileName}")]
    public IActionResult GetImage(string fileName)
    {
        var path = Path.Combine(_uploadsFolder, fileName);
        if (!System.IO.File.Exists(path))
            return NotFound();

        var mime = GetMimeType(fileName);
        var bytes = System.IO.File.ReadAllBytes(path);
        return File(bytes, mime);
    }

    [HttpDelete("{fileName}")]
    public IActionResult DeleteImage(string fileName)
    {
        var path = Path.Combine(_uploadsFolder, fileName);
        if (!System.IO.File.Exists(path))
            return NotFound();

        System.IO.File.Delete(path);
        return Ok("Imagen eliminada");
    }

    private string GetMimeType(string fileName)
    {
        var extension = Path.GetExtension(fileName).ToLowerInvariant();
        return extension switch
        {
            ".jpg" or ".jpeg" => "image/jpeg",
            ".png" => "image/png",
            ".gif" => "image/gif",
            _ => "application/octet-stream"
        };
    }
}
