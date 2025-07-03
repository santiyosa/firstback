using Microsoft.AspNetCore.Mvc;
using BackendProject.imagenes;

namespace BackendProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {

        private readonly AzureBlobStorageService _blobService;

        public ImagesController(AzureBlobStorageService blobService)
        {
            _blobService = blobService;
        }


        [HttpPost]
        public async Task<IActionResult> UploadImage([FromForm] ImageUploadDto model)
        {
            if (model.File == null || model.File.Length == 0)
                return BadRequest("No se subió ningún archivo.");

            var id = Guid.NewGuid();
            var sanitizedFileName = SanitizeFileName(Path.GetFileName(model.File.FileName));
            var fileName = $"{id}_{sanitizedFileName}";
            // Cambia el nombre del archivo antes de subirlo
            var formFile = new FormFile(model.File.OpenReadStream(), 0, model.File.Length, string.Empty, fileName)
            {
                Headers = model.File.Headers,
                ContentType = model.File.ContentType
            };
            var url = await _blobService.UploadFileAsync(formFile);

            var response = new ImageUploadResponseDto
            {
                Id = id,
                FileName = fileName,
                Name = model.Name,
                Position = model.Position,
                Url = url
            };

            return Ok(response);
        }



        [HttpGet]
        public async Task<IActionResult> GetAllImages()
        {
            var blobs = await _blobService.GetAllBlobs();
            var files = new List<ImageInfoDto>();
            foreach (var blob in blobs)
            {
                var url = await _blobService.GetBlobUrlAsync(blob);
                files.Add(new ImageInfoDto
                {
                    FileName = blob,
                    Url = url
                });
            }
            files = files.OrderBy(i => i.FileName).ToList();
            return Ok(files);
        }


        [HttpGet("{fileName}")]
        public async Task<IActionResult> GetImage(string fileName)
        {
            var stream = await _blobService.GetFileAsync(fileName);
            if (stream == null)
                return NotFound("La imagen no fue encontrada.");

            var mime = GetMimeType(fileName);
            return File(stream, mime);
        }


        [HttpDelete("{fileName}")]
        public async Task<IActionResult> DeleteImage(string fileName)
        {
            var deleted = await _blobService.DeleteFileAsync(fileName);
            if (!deleted)
                return NotFound(new DeleteImageResponseDto
                {
                    FileName = fileName,
                    Message = "La imagen no fue encontrada."
                });

            return Ok(new DeleteImageResponseDto
            {
                FileName = fileName,
                Message = "Imagen eliminada correctamente."
            });
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

        private string SanitizeFileName(string input)
        {
            foreach (var c in Path.GetInvalidFileNameChars())
            {
                input = input.Replace(c, '_');
            }
            return input.Replace(" ", "_").ToLowerInvariant();
        }
    }
}