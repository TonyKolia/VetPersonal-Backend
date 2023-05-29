using Microsoft.AspNetCore.Mvc;

namespace VetPersonal.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : CustomControllerBase
    {
        private readonly IConfiguration _config;

        public ImagesController(IConfiguration config)
        {
            this._config = config;
        }

        [HttpGet]
        [Route("Page/{imageName}")]
        public async Task<ActionResult> GetPageImage(string imageName)
        {
            if (!imageName.Contains('.'))
                return StatusCode(StatusCodes.Status400BadRequest);

            var bookImagesPathBase = _config.GetValue<string>("ImagePaths:Pages");
            var file = await System.IO.File.ReadAllBytesAsync(Path.Combine(bookImagesPathBase, imageName));
            return File(file, $"image/{GetFileExtension(imageName)}");
        }
    }
}
