using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Contents.API.Entities
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Username { get; set; }
        [Required]
        [MaxLength(50)]
        public string Password { get; set; }
        [Required]
        [MaxLength(50)]
        public string Email { get; set; }

        public List<Content> Contents { get; set; } = new List<Content>();
        public User(string username, string password, string email)
        {
            Username = username;
            Password = password;
            Email = email;
        }
    }
}
