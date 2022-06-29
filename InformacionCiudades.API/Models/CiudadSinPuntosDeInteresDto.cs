namespace InformacionCiudades.API.Models
{
    public class CiudadSinPuntosDeInteresDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string? Descripcion { get; set; }
    }
}
