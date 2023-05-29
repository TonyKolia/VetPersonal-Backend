using Microsoft.EntityFrameworkCore;

namespace VetPersonal.API.Repositories
{
    public class PageImageRepository : IPageImageRepository
    {
        private readonly VetPersonalDbContext _db;

        public PageImageRepository(VetPersonalDbContext db) => this._db = db;

        public async Task<PageImage> GetPageImage(int pageId) => await _db.PageImages.FirstOrDefaultAsync(x => x.Page == pageId);
    }
}
