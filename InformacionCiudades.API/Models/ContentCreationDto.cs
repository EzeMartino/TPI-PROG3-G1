using Contents.API.Entities;
using System.ComponentModel.DataAnnotations;

namespace Contents.API.Models
{
    public class ContentCreationDto
    {
        [Required(ErrorMessage = "Agregá un titulo")]
        [MaxLength(50)]
        public string Title { get; set; }
        [Required(ErrorMessage = "Agregá un comentario")]
        [MaxLength(200)]
        public string Comment { get; set; }
        [MaxLength(int.MaxValue)]
        public int Duration { get; set; }
        [Required(ErrorMessage = "Agregá una categoria")]
        [MaxLength(200)]
        public string Category { get; set; }
    }
}