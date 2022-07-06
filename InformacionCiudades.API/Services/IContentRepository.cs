using Contents.API.Entities;
using Contents.API.Models;

namespace Contents.API.Services
{
    public interface IContentRepository
    {
        public IEnumerable<User> GetUsers();
        public User? GetUser(int idUser);

        public void CreateUser(User user);

        public IEnumerable<Content> GetContents();
        public Content? GetContent(int idContent);
        public void CreateContent(Content content);
        public bool SaveChanges();
        public void DeleteUser(int idUser);

        public void DeleteContent(int idContent);
        public bool UserExists(int idUser);
        public void AddContentToUser(int idUser, Content content);

        public Content? GetContentInUser(int idUser, int idContent);

        public bool ContentExists(int idContent);

    }

}
