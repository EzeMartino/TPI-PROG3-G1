using Contents.API.Entities;
using System.ComponentModel.DataAnnotations;

namespace Contents.API.Models
{
    public class ContentUpdateDto
    {
        [Required(ErrorMessage = "Agregá un titulo")]
        [MaxLength(50)]
        public string Title { get; set; } = string.Empty;
        
        
        [Required]
        [MaxLength(int.MaxValue)]
        public int Duration { get; set; }
        [Required]
        public string Category { get; set; }
        [Required]
        [MaxLength(200)]
        public string? Comment { get; set; }
        [Required]
        public int Rating { get; set; }
    }
}