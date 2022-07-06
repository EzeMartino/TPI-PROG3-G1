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

        public string Category { get; set; }

        [MaxLength(200)]
        public string? Comment { get; set; }


        [Required]
        public int Rating { get; set; }

        public User? User { get; set; }
        
        public int UserId { get; set; }

        public ICollection<Review> Reviews { get; set; } = new List<Review>();


        public Content(string title, int duration, string comment, string category)
        {
            Title = title.Trim();
            Duration = duration;
            Comment = comment;
            Category = category;
        }
    }
}
