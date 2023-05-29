using Microsoft.EntityFrameworkCore;

namespace VetPersonal.API.Repositories
{
    public class PagesRepository : IPagesRepository
    {
        private readonly VetPersonalDbContext _db;

        public PagesRepository(VetPersonalDbContext db) => this._db = db;

        public async Task<IEnumerable<Page>> GetPages() => await _db.Pages.ToListAsync();

        public async Task<IEnumerable<Page>> GetPages(string languange) => await _db.Pages.Where(x => x.Language == languange && x.Visible == 1).OrderBy(x => x.PageOrder).ToListAsync();

        public async Task<int?> GetPageId(string route) => (await _db.Pages.FirstOrDefaultAsync(x => x.Route == $"/{route}"))?.Id;
    }
}
