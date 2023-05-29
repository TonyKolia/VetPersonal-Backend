namespace VetPersonal.API.Repositories
{
    public interface IPageImageRepository
    {
        public Task<PageImage> GetPageImage(int pageId);
    }
}
