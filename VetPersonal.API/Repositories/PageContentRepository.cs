using Microsoft.EntityFrameworkCore;

namespace VetPersonal.API.Repositories
{
    public class PageContentRepository : IPageContentRepository
    {
        private readonly VetPersonalDbContext _db;

        public PageContentRepository(VetPersonalDbContext db) => this._db = db;

        public async Task<IEnumerable<PageContent>> GetPageContent(int pageId) => await _db.PageContents.Where(x => x.Page == pageId).ToListAsync();

        public async Task<IEnumerable<PageContent>> GetPageContent(int pageId, string language) => await _db.PageContents.Where(x => x.Page == pageId && x.Language == language).ToListAsync();
    }
}
