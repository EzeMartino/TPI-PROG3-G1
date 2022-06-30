using Contents.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace Contents.API.DBContexts
{
    public class ContentContext : DbContext
    {
        public DbSet<Content> Contents { get; set; } 
        public DbSet<Category> Categories { get; set; }

        public ContentContext(DbContextOptions<ContentContext> options) : base(options) //Acá estamos llamando al constructor de DbContext que es el que acepta las opciones
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Ciudad>().HasMany(c => c.PuntosDeInteres).WithOne(p => p.Ciudad).HasForeignKey(c => c.CiudadId);

            var contents = new Content[3]
            {
                new Content("Peaky Blinders", 36, "Muy picante", new Category("Serie")),
                new Content("The Walking Dead", 80, "Atrapante", new Category("Serie")),
                new Content("Movie Dick", 361, "buena pelicula", new Category("Pelicula"))
            };
            modelBuilder.Entity<Content>().HasData(contents);


            base.OnModelCreating(modelBuilder);
        }
    }
}
