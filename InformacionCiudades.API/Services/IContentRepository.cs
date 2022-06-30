using Contents.API.Entities;

namespace Contents.API.Services
{
    public interface IContentRepository
    {
        public IEnumerable<Content> GetContents();
        public Content? GetContent(int idContent);
        public bool SaveChanges();
        void DeleteContent(int idContent);
    }
}
