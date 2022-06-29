using System.ComponentModel.DataAnnotations;

namespace InformacionCiudades.API.Models
{
    public class PuntoDeInteresParaUpdateDto
    {
        [Required(ErrorMessage = "Agregá un nombre")]
        [MaxLength(50)]
        public string Nombre { get; set; } = string.Empty;
        [MaxLength(500)]
        public string? Descripcion { get; set; }
    }
}