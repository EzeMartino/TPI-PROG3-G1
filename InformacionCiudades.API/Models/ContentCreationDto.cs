using Contents.API.Entities;
using System.ComponentModel.DataAnnotations;

namespace Contents.API.Models
{
    public class ContentCreationDto//Puede ser q tengamos entidades que se creen con un Id específico,
                                              //igualmente en ese caso recomienda usar un Dto aparte para poder hacer
                                              //cambios mas tranquilo. LA IDEA ES SEPARAR DTOs DE CREACIÓN, UPDATE Y CONSULTAS.
    {
        [Required(ErrorMessage = "Agregá un titulo")]
        [MaxLength(50)]
        public string Title { get; set; } = string.Empty;
        [MaxLength(200)]
        public string? Comment { get; set; }
        [MaxLength(int.MaxValue)]
        public int Duration { get; set; }
        public Category Category { get; set; }
    }
}