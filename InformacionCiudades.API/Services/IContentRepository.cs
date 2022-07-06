using Contents.API.Entities;
using Contents.API.Models;

namespace Contents.API.Services
{
    public interface IContentRepository
    {
        public IEnumerable<Content> GetContents();
        public Content? GetContent(int idContent);
        public void CreateContent(Content content);
        public bool SaveChanges();
        public void DeleteContent(int idContent);
    }
}
