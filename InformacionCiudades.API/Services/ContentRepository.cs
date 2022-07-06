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

        public IEnumerable<User> GetUsers()
        {
            return _context.Users.OrderBy(x => x.Id).ToList();
        }
        public User? GetUser(int idUser)
        {
            return _context.Users.Where(u => u.Id == idUser).FirstOrDefault();
        }

        public void CreateUser(User user)
        {
            _context.Users.Add(user);
        }

        public void DeleteUser(int idUser)
        {
            if (GetUser(idUser) == null)
            {
                throw new ArgumentException("Content nof found");
            }
            else
            {
                _context.Users.Remove(GetUser(idUser));
            }

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
                throw new ArgumentException("Content nof found");

            _context.Contents.Remove(GetContent(idContent));

        }
        public bool UserExists(int idUser)
        {
            return _context.Users.Any(c => c.Id == idUser);
        }

        public void AddContentToUser(int idUser, Content content)
        {
            var user = GetUser(idUser);
            if(user != null)
            {
                user.Contents.Add(content);
            }
        }

        public Content? GetContentInUser(int idUser, int idContent)
        {
            return _context.Contents.Where(c => c.UserId == idUser && c.Id == idContent).FirstOrDefault();
        }

        public bool ContentExists(int idContent)
        {
            return _context.Contents.Any(c => c.Id == idContent);
        }
    }
}
