using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InformacionCiudades.API.Entities
{
    public class PuntoDeInteres
    {
        [Key] //Esto es opcional si se sigue la convención
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] //También por convención no hace falta. Identity genera un nuevo Id por cada creación.
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Nombre { get; set; }
        
        [MaxLength(250)]
        public string? Descripcion { get; set; } //Agregarlo en la segunda migración para ver como funciona la actualización.

        [ForeignKey("CiudadId")]
        public Ciudad? Ciudad { get; set; }
        public int CiudadId { get; set; }
        public PuntoDeInteres(string nombre)
        {
            Nombre = nombre;
        }
    }
}
