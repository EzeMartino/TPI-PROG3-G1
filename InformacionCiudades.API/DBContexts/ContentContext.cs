using Contents.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace Contents.API.DBContexts
{
    public class ContentContext : DbContext
    {
        public DbSet<Content> Contents { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<User> Users { get; set; }

        public ContentContext(DbContextOptions<ContentContext> options) : base(options) //Acá estamos llamando al constructor de DbContext que es el que acepta las opciones
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
