using Contents.API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Contents.API.Controllers
{
    [Route("api/authentication")] //Especificamos un path de login
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IConfiguration _config;

        public class AuthenticationRequestBody // Esta clase podría estar en un archivo aparte, pero como no es una entidad ni un DTO y solo se usa para el login podemos dejarla acá.
        {
            public string? Username { get; set; }
            public string? Password { get; set; }
        }

        public AuthenticationController(IConfiguration config)
        {
            _config = config; //Hacemos la inyección para poder usar el appsettings.json
        }

        [HttpPost("authenticate")] //Vamos a usar un POST ya que debemos enviar los datos para hacer el login
        public ActionResult<string> Authenticate(AuthenticationRequestBody authenticationRequestBody) //Enviamos como parámetro la clase que creamos arriba
        {
            //Paso 1: Validamos las credenciales
            var user = ValidarCredenciales(authenticationRequestBody.Username, authenticationRequestBody.Password); //Lo primero que hacemos es llamar a una función que valide los parámetros que enviamos.

            if (user is null) //Si el la función de arriba no devuelve nada es porque los datos son incorrectos, por lo que devolvemos un Unauthorized (un status code 401).
                return Unauthorized();

            //Paso 2: Crear el token
            var claveDeSeguridad = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_config["Authentication:SecretForKey"])); //Traemos la SecretKey del Json. agregar antes: using Microsoft.IdentityModel.Tokens;

            var credenciales = new SigningCredentials(claveDeSeguridad, SecurityAlgorithms.HmacSha256);

            //Los claims son datos en clave->valor que nos permite guardar data del usuario.
            var claimsForToken = new List<Claim>();
            claimsForToken.Add(new Claim("sub", user.Id.ToString())); //"sub" es una key estándar que significa unique user identifier, es decir, si mandamos el id del usuario por convención lo hacemos con la key "sub".
            claimsForToken.Add(new Claim("username", user.Username));
            claimsForToken.Add(new Claim("password", user.Password)); 
            claimsForToken.Add(new Claim("email", user.Email));

            var jwtSecurityToken = new JwtSecurityToken( //agregar using System.IdentityModel.Tokens.Jwt; Acá es donde se crea el token con toda la data que le pasamos antes.
              _config["Authentication:Issuer"],
              _config["Authentication:Audience"],
              claimsForToken,
              DateTime.UtcNow,
              DateTime.UtcNow.AddHours(1),
              credenciales);

            var tokenToReturn = new JwtSecurityTokenHandler() //Pasamos el token a string
                .WriteToken(jwtSecurityToken);

            return Ok(tokenToReturn);
        }

        //[HttpPost]
        //public ActionResult<string> CreateUser(string username, string password, string email)
        //{

        //}

        private User ValidarCredenciales(string? userName, string? password)
        {
            // Acá devolvemos un usuario nuevo independientemente de lo que mande el usuario a fines ilustrativos. Acá deberíamos ir a la base de datos y verificar que el usuario existe y que la password es correcta.
            return new User("tomisacripanti", "TomasSacripanti987", "sacripantitomas@gmail.com");
        }

    }
}
