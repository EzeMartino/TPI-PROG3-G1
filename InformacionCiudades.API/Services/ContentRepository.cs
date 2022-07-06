using Contents.API.DBContexts;
using Contents.API.Entities;
using Contents.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Contents.API.Services
{
    public class ContentRepository : IContentRepository
    {
        private readonly ContentContext _context;

        public ContentRepository(ContentContext context)
        {
            _context = context;
        }
        public Content? GetContent(int idContent)
        {
            return _context.Contents.Where(c => c.Id == idContent).FirstOrDefault();
        }

        public IEnumerable<Content> GetContents()
        {
            return _context.Contents.OrderBy(x => x.Title).ToList();
        }

        public void CreateContent(Content content)
        {
            _context.Contents.Add(content);
        }


        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void DeleteContent(int idContent)
        {
            if (GetContent(idContent) == null)
            {
                throw new ArgumentException("Content nof found");
            } else
            {
                _context.Contents.Remove(GetContent(idContent));
            }
            
        }

    }
}
