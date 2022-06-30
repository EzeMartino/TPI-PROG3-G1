using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Contents.API.Entities
{
    public class Content
    {
        [Key] //Esto es opcional si se sigue la convención
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] //También por convención no hace falta. Identity genera un nuevo Id por cada creación.
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Title { get; set; }
        [Required]
        public int Duration { get; set; }

        [MaxLength(200)]
        public string? Comment { get; set; }

        public string Category { get; set; } 

        public Content(string title, int duration, string comment, string category)
        {
            Title = title.Trim();
            Duration = duration;
            Comment = comment;
            Category = category;
        }
    }
}
