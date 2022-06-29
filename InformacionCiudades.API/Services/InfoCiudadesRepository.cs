using InformacionCiudades.API.DBContexts;
using InformacionCiudades.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace InformacionCiudades.API.Services
{
    public class InfoCiudadesRepository : IInfoCiudadesRepository
    {
        private readonly InformacionCiudadesContext _context;

        public InfoCiudadesRepository(InformacionCiudadesContext context)
        {
            _context = context;
        }
        public Ciudad? GetCiudad(int idCiudad, bool incluirPuntosDeInteres)
        {
            if (incluirPuntosDeInteres)
                return _context.Ciudades.Include(c => c.PuntosDeInteres)
                    .Where(c => c.Id == idCiudad).FirstOrDefault();

            return _context.Ciudades.Where(c => c.Id == idCiudad).FirstOrDefault();
        }

        public IEnumerable<Ciudad> GetCiudades()
        {
            return _context.Ciudades.OrderBy(x => x.Nombre).ToList();
        }

        public PuntoDeInteres? GetPuntoDeInteresDeCiudad(int idCiudad, int idPuntoDeInteres)
        {
            return _context.PuntosDeInteres.Where(p => p.CiudadId == idCiudad && p.Id == idPuntoDeInteres).FirstOrDefault();
        }

        public IEnumerable<PuntoDeInteres> GetPuntosDeInteresDeCiudad(int idCiudad)
        {
            return _context.PuntosDeInteres.Where(p => p.CiudadId == idCiudad).ToList();
        }

        public bool ExisteCiudad(int idCiudad)
        {
            return _context.Ciudades.Any(c => c.Id == idCiudad);
        }

        public void AgregarPuntoDeInteresACiudad(int idCiudad, PuntoDeInteres puntoDeInteres)
        {
            var ciudad = GetCiudad(idCiudad, false);
            if (ciudad != null)
                ciudad.PuntosDeInteres.Add(puntoDeInteres);
        }

        public bool GuardarCambios()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void EliminarPuntoDeInteres(PuntoDeInteres puntoDeInteres)
        {
            _context.PuntosDeInteres.Remove(puntoDeInteres);
        }

        public bool NombreCiudadConcuerdaConIdCiudad(string? nombreCiudad, int idCiudad)
        {
            return _context.Ciudades.Any(c => c.Id == idCiudad && c.Nombre == nombreCiudad);
        }
    }
}
