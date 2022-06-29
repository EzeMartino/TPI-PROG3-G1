using InformacionCiudades.API.Entities;

namespace InformacionCiudades.API.Services
{
    public interface IInfoCiudadesRepository
    {
        public IEnumerable<Ciudad> GetCiudades();
        public Ciudad? GetCiudad(int idCiudad, bool incluirPuntosDeInteres);
        public IEnumerable<PuntoDeInteres> GetPuntosDeInteresDeCiudad(int idCiudad);
        public PuntoDeInteres? GetPuntoDeInteresDeCiudad(int idCiudad, int idPuntoDeInteres);
        public bool ExisteCiudad(int idCiudad);
        public void AgregarPuntoDeInteresACiudad(int idCiudad, PuntoDeInteres puntoDeInteres);
        void EliminarPuntoDeInteres(PuntoDeInteres puntoDeInteres);
        public bool GuardarCambios();
        bool NombreCiudadConcuerdaConIdCiudad(string? nombreCiudad, int idCiudad);
    }
}
