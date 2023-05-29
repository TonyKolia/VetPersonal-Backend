namespace VetPersonal.API.Repositories
{
    public interface IPageContentRepository
    {
        public Task<IEnumerable<PageContent>> GetPageContent(int pageId);
        public Task<IEnumerable<PageContent>> GetPageContent(int pageId, string language);
    }
}
