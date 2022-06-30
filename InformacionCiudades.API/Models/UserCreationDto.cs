using Contents.API.Entities;
using System.ComponentModel.DataAnnotations;

namespace Contents.API.Models
{
    public class UserCreationDto
    {
        [Required(ErrorMessage = "Agregá un username")]
        [MaxLength(50)]
        public string Username { get; set; }
        [Required(ErrorMessage = "Agregá una contraseña")]
        [MaxLength(50)]
        public string Password { get; set; }
        public string Email { get; set; }
    }
}