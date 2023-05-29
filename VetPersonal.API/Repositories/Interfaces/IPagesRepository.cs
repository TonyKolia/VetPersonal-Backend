namespace VetPersonal.API.Repositories
{
    public interface IPagesRepository
    {
        public Task<IEnumerable<Page>> GetPages();
        public Task<IEnumerable<Page>> GetPages(string language);
        public Task<int?> GetPageId(string route);
    }
}
