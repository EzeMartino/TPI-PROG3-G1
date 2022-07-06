using AutoMapper;
using Contents.API.Entities;
using Contents.API.Models;
using Contents.API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Contents.API.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/users")]
    public class UsersController : ControllerBase
    {
        private readonly IContentRepository _contentRepository;
        private readonly IMapper _mapper;

        public UsersController(IContentRepository contentRepository, IMapper mapper)
        {
            _contentRepository = contentRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<UserWithoutContentsDto>> GetUsers()
        {
            var users = _contentRepository.GetUsers();

            return Ok(_mapper.Map<IEnumerable<UserWithoutContentsDto>>(users));
        }

        [HttpGet("{id}", Name = "GetUser")]
        public IActionResult GetUser(int id) //Ahora devolvemos un IActionResult para que sea más genérico, ya que ahora podemos devolver CiudadDto o CiudadSinPuntosDeInteresDto
        {
            var user = _contentRepository.GetUser(id);
            if (user == null)
                return NotFound();

            return Ok(_mapper.Map<UserDto>(user));
        }

        [HttpPost]
        public ActionResult<UserDto> CreateUser(UserCreationDto user)
        {
            var newUser = _mapper.Map<User>(user);

            _contentRepository.CreateUser(newUser);
            _contentRepository.SaveChanges();

            var userToReturn = _mapper.Map<UserDto>(newUser);

            return CreatedAtRoute("GetUser", new { id = newUser.Id }, userToReturn);
        }

        [HttpPut("{idUser}")]
        public ActionResult UpdateUser(int idUser, UserCreationDto user)
        {
            if (!_contentRepository.UserExists(idUser))
                return NotFound();

            var userInDB = _contentRepository.GetUser(idUser);
            if (userInDB is null)
                return NotFound();

            _mapper.Map(user, userInDB);
            _contentRepository.SaveChanges();

            return NoContent();
        }
    }
}
