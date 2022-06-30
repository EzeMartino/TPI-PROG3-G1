using Contents.API.Entities;
using System.ComponentModel.DataAnnotations;

namespace Contents.API.Models
{
    public class ContentCreationDto
    {
        [Required(ErrorMessage = "Agregá un titulo")]
        [MaxLength(50)]
        public string Title { get; set; } = string.Empty;
        [MaxLength(200)]
        public string? Comment { get; set; }
        [MaxLength(int.MaxValue)]
        public int Duration { get; set; }
        public string Category { get; set; }
    }
}