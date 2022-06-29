using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InformacionCiudades.API.Entities
{
    public class Ciudad
    {
        [Key] //Esto es opcional si se sigue la convención
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] //También por convención no hace falta. Identity genera un nuevo Id por cada creación.
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Nombre { get; set; }

        [MaxLength(200)]
        public string? Descripcion { get; set; }

        public ICollection<PuntoDeInteres> PuntosDeInteres { get; set; } = new List<PuntoDeInteres>(); //Lo seteamos a una nueva colección para evitar que retorne un null en algún momento de la ejecución.

        public Ciudad(string nombre)
        {
            Nombre = nombre.Trim();
        }
    }
}
