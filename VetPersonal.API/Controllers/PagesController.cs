using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VetPersonal.API.Repositories;

namespace VetPersonal.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PagesController : ControllerBase
    {
        private readonly IPagesRepository _pagesRepository;

        public PagesController(IPagesRepository pagesRepository)
        {
            this._pagesRepository = pagesRepository;
        }

        [HttpGet]
        [Route("language/{language}")]
        public async Task<ActionResult<IEnumerable<Page>>> GetPages(string language)
        {
            try
            {
                var pages = await _pagesRepository.GetPages(language);
                return StatusCode(StatusCodes.Status200OK, pages);
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

    }
}
