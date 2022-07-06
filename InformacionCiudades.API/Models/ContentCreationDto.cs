using Contents.API.Entities;
using System.ComponentModel.DataAnnotations;

namespace Contents.API.Models
{
    public class ContentCreationDto
    {
        [Required(ErrorMessage = "Agregá un titulo")]
        [MaxLength(50)]
        public string Title { get; set; }

        [Required]
        public int Duration { get; set; }

        [Required(ErrorMessage = "Agregá una categoria")]
        [MaxLength(200)]
        public string Category { get; set; }

        [Required(ErrorMessage = "Agregá un comentario")]
        [MaxLength(200)]
        public string Comment { get; set; }

        [Required(ErrorMessage = "Agrega un puntaje del 1 al 10")]
        public int Rating { get; set; }

    }
}