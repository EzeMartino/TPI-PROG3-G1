namespace InformacionCiudades.API.Models;
public class TuMamáDTO
{
    public int Id { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public string? Descripcion { get; set; }

    public ICollection<PuntoDeInteresDto> PuntosDeInteres { get; set; } = new List<PuntoDeInteresDto>(); //Lo seteamos a una nueva colección para evitar que retorne un null en algún momento de la ejecución.

    public int CantidadPuntosDeInteres
    {
        get { return PuntosDeInteres.Count; }
    }
}

