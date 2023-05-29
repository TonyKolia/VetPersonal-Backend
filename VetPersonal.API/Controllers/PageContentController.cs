using Microsoft.AspNetCore.Mvc;
using VetPersonal.API.Models;
using VetPersonal.API.Repositories;

namespace VetPersonal.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PageContentController : CustomControllerBase
    {
        private readonly IPageContentRepository _pageContentRepository;
        private readonly IPagesRepository _pagesRepository;
        private readonly IPageImageRepository _pageImageRepository;

        public PageContentController(IPageContentRepository pageContentRepository, IPagesRepository pagesRepository, IPageImageRepository pageImageRepository)
        {
            this._pageContentRepository = pageContentRepository;
            this._pagesRepository = pagesRepository;
            this._pageImageRepository = pageImageRepository;
        }

        [HttpGet]
        [Route("{route}/{language}")]
        public async Task<ActionResult<IEnumerable<Content>>> GetPageContent(string route, string language)
        {
            try
            {
                var pageId = await _pagesRepository.GetPageId(route);
                if (!pageId.HasValue)
                    return StatusCode(StatusCodes.Status404NotFound);

                var content = await _pageContentRepository.GetPageContent(pageId.Value, language);
                var pageContent = new Content
                {
                    Title = content.FirstOrDefault(x => x.Type == 1)?.Text,
                    Headers = content.Where(x => x.Type == 2).OrderBy(x => x.ContentOrder).Select(x => x.Text).ToList(),
                    Paragraphs = content.Where(x => x.Type == 3).OrderBy(x => x.ContentOrder).Select(x => x.Text).ToList(),
                    ImageName = (await _pageImageRepository.GetPageImage(pageId.Value))?.ImageName
                };

                return StatusCode(StatusCodes.Status200OK, pageContent);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
