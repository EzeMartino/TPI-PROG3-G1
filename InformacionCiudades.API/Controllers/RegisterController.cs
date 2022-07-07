using AutoMapper;
using Contents.API.Entities;
using Contents.API.Models;
using Contents.API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Contents.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private readonly IContentRepository _contentRepository;
        private readonly IMapper _mapper;

        public RegisterController(IContentRepository contentRepository, IMapper mapper)
        {
            _contentRepository = contentRepository;
            _mapper = mapper;
        }
        //[HttpGet("{id}", Name = "GetRegister")]
        //public IActionResult GetRegister(int id)
        //{
        //    return Ok(id);
        //}

        [HttpPost]
        public ActionResult<UserDto> RegisterUser(UserCreationDto user)
        {
            var newUser = _mapper.Map<User>(user);

            if (_contentRepository.UserNameExists(newUser.Username))
                return BadRequest("Nombre de usuario ya existe");

            _contentRepository.CreateUser(newUser);
            _contentRepository.SaveChanges();

            var userToReturn = _mapper.Map<UserDto>(newUser);
            string URI = $"https://localhost:7172/api/Register{userToReturn.Id}";
            return Created(URI, userToReturn);

            //return CreatedAtRoute("GetRegister", new { id = newUser.Id }, userToReturn);
        }
    }
}
