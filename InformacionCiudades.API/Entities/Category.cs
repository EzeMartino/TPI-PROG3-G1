using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Contents.API.Entities
{
    public class Category
    {
        [Key] //Esto es opcional si se sigue la convención
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] //También por convención no hace falta. Identity genera un nuevo Id por cada creación.
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Title { get; set; }

        public Category(string title)
        {
            Title = title.Trim();
        }
    }
}
