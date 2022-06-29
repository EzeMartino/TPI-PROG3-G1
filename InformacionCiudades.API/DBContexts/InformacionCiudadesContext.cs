using InformacionCiudades.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace InformacionCiudades.API.DBContexts
{
    public class InformacionCiudadesContext : DbContext
    {
        public DbSet<Ciudad> Ciudades { get; set; } //lo que hagamos con LINQ sobre estos DbSets lo va a transformar en consultas SQL
        public DbSet<PuntoDeInteres> PuntosDeInteres { get; set; } //Los warnings los podemos obviar porque DbContext se encarga de eso.

        public InformacionCiudadesContext(DbContextOptions<InformacionCiudadesContext> options) : base(options) //Acá estamos llamando al constructor de DbContext que es el que acepta las opciones
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Ciudad>().HasMany(c => c.PuntosDeInteres).WithOne(p => p.Ciudad).HasForeignKey(c => c.CiudadId);

            var ciudades = new Ciudad[3]
            {
                new Ciudad("New York City")
                {
                    Id = 1,
                    Descripcion = "The one with that big park.",
                },
                new Ciudad("Antwerp")
                {
                    Id = 2,
                    Descripcion = "The one with the cathedral that was never really finished.",

                },
                new Ciudad("Paris")
                {
                    Id = 3,
                    Descripcion = "The one with that big tower.",
                }
            };
            modelBuilder.Entity<Ciudad>().HasData(ciudades);

            modelBuilder.Entity<PuntoDeInteres>().HasData(
                new PuntoDeInteres("Central Park")
                {
                    Id = 1,
                    Descripcion = "The most visited urban park in the United States.",
                    CiudadId = ciudades[0].Id
                },
                new PuntoDeInteres("Empire State Building")
                {
                    Id = 2,
                    Descripcion = "A 102-story skyscraper located in Midtown Manhattan.",
                    CiudadId = ciudades[0].Id
                },

                new PuntoDeInteres("Cathedral of Our Lady")
                {
                    Id = 3,
                    Descripcion = "A Gothic style cathedral, conceived by architects Jan and Pieter Appelmans.",
                    CiudadId = ciudades[1].Id
                },
                new PuntoDeInteres("Antwerp Central Station")
                {
                    Id = 4,
                    Descripcion = "The the finest example of railway architecture in Belgium.",
                    CiudadId = ciudades[1].Id
                },
                new PuntoDeInteres("Eiffel Tower")
                {
                    Id = 5,
                    Descripcion = "A wrought iron lattice tower on the Champ de Mars, named after engineer Gustave Eiffel.",
                    CiudadId = ciudades[2].Id
                },
                new PuntoDeInteres("The Louvre")
                {
                    Id = 6,
                    Descripcion = "The world's largest museum.",
                    CiudadId = ciudades[2].Id
                });

            base.OnModelCreating(modelBuilder);
        }
    }
}
