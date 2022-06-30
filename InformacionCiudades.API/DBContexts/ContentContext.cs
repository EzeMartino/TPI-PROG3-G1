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

            new ContentConfig(modelBuilder.Entity<Content>());
            new UserConfig(modelBuilder.Entity<User>());

            var contents = new Content[3]
            {
                new Content("Peaky Blinders", 36, "Muy picante", "Serie")
                {
                    Id=1,
                },
                new Content("The Walking Dead", 80, "Atrapante", "Serie")
                {
                    Id=2,
                },
                new Content("Movie Dick", 361, "buena pelicula", "Pelicula")
                {
                    Id=3,
                }
            };
            modelBuilder.Entity<Content>().HasData(contents);
            base.OnModelCreating(modelBuilder);
        }
    }
}
