using InformacionCiudades.API.Models;

namespace InformacionCiudades.API
{
    public class CiudadesData
    {
        public List<CiudadDto> Ciudades { get; set; }

        //public static CiudadesData InstanciaActual { get; } = new CiudadesData();

        public CiudadesData()
        {
            Ciudades = new List<CiudadDto>()
            {
                new CiudadDto()
                {
                     Id = 1,
                     Nombre = "New York City",
                     Descripcion = "The one with that big park.",
                     PuntosDeInteres = new List<PuntoDeInteresDto>()
                     {
                         new PuntoDeInteresDto() {
                             Id = 1,
                             Nombre = "Central Park",
                             Descripcion = "The most visited urban park in the United States." },
                          new PuntoDeInteresDto() {
                             Id = 2,
                             Nombre = "Empire State Building",
                             Descripcion = "A 102-story skyscraper located in Midtown Manhattan." },
                     }
                },
                new CiudadDto()
                {
                    Id = 2,
                    Nombre = "Antwerp",
                    Descripcion = "The one with the cathedral that was never really finished.",
                    PuntosDeInteres = new List<PuntoDeInteresDto>()
                     {
                         new PuntoDeInteresDto() {
                             Id = 3,
                             Nombre = "Cathedral of Our Lady",
                             Descripcion = "A Gothic style cathedral, conceived by architects Jan and Pieter Appelmans." },
                          new PuntoDeInteresDto() {
                             Id = 4,
                             Nombre = "Antwerp Central Station",
                             Descripcion = "The the finest example of railway architecture in Belgium." },
                     }
                },
                new CiudadDto()
                {
                    Id= 3,
                    Nombre = "Paris",
                    Descripcion = "The one with that big tower.",
                    PuntosDeInteres = new List<PuntoDeInteresDto>()
                     {
                         new PuntoDeInteresDto() {
                             Id = 5,
                             Nombre = "Eiffel Tower",
                             Descripcion = "A wrought iron lattice tower on the Champ de Mars, named after engineer Gustave Eiffel." },
                          new PuntoDeInteresDto() {
                             Id = 6,
                             Nombre = "The Louvre",
                             Descripcion = "The world's largest museum." },
                     }
                }
            };
        }
    }
}
