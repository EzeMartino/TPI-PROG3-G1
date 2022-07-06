using Contents.API.DBContexts.Config;
using Contents.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace Contents.API.DBContexts
{
    public class ContentContext : DbContext
    {
        public DbSet<Content> Contents { get; set; }
        public DbSet<User> Users { get; set; }

        public ContentContext(DbContextOptions<ContentContext> options) : base(options) //Acá estamos llamando al constructor de DbContext que es el que acepta las opciones
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var contents = new Content[3]
            {
                new Content("Title 1", 12, "Comment 1", "Category 1")
                {
                    Id = 1,
                },
                new Content("Title 2", 12, "Comment 2", "Category 2")
                {
                    Id = 2,
                },
                new Content("Title 3", 12, "Comment 3", "Category 3")
                {
                    Id = 3,
                },
            };

            modelBuilder.Entity<Content>().HasData(contents);
            var users = new User[3]
            {
                new User("User 1", "password1", "email1@email.com"){Id=1},
                new User("User 2", "password2", "email2@email.com"){Id=2},
                new User("User 3", "password3", "email3@email.com"){Id=3},
            };
            modelBuilder.Entity<User>().HasData(users);
            //new ContentConfig(modelBuilder.Entity<Content>());
            //new UserConfig(modelBuilder.Entity<User>());
            base.OnModelCreating(modelBuilder);
        }
    }
}
