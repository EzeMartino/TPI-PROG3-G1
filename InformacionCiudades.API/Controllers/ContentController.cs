using AutoMapper;

using Newtonsoft.Json.Linq;

using Contents.API.Entities;
using Contents.API.Models;
using Contents.API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Contents.API.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/contents")]
    public class ContentController : ControllerBase
    {
        private readonly IContentRepository _contentRepository;
        private readonly IMapper _mapper;

        public ContentController(IContentRepository contentRepository, IMapper mapper)
        {
            _contentRepository = contentRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ContentDto>> GetContents() //JsonResults implementa IActionResults
        {
            var contents = _contentRepository.GetContents();

            return Ok(_mapper.Map<IEnumerable<ContentDto>>(contents));

        }

        [HttpGet("{id}", Name = "GetContent")]
        public IActionResult GetContent(int id) //Ahora devolvemos un IActionResult para que sea más genérico, ya que ahora podemos devolver CiudadDto o CiudadSinPuntosDeInteresDto
                                                                                    //incluirPuntosDeInteres se envía como parámetro en la url al final de la misma de la siguiente manera /api/ciudades/1?incluirPuntosDeInteres=true
        {
            var content = _contentRepository.GetContent(id);
            if (content == null)
                return NotFound();


            return Ok(_mapper.Map<ContentDto>(content));
        }
        [HttpPost]
        public ActionResult<ContentDto> CreateContent(int idUser, ContentCreationDto contentRequestBody)
        {
            if (!_contentRepository.UserExists(idUser))
            {
                return NotFound();
            }
            
            if (contentRequestBody.Title == "" || contentRequestBody.Title == "" || contentRequestBody.Duration == 0 || contentRequestBody.Comment == "" || contentRequestBody.Comment == "" || contentRequestBody.Category == "")
            {
                return BadRequest();
            }
            var newContent = _mapper.Map<Content>(contentRequestBody);
            _contentRepository.AddContentToUser(idUser, newContent);
            _contentRepository.CreateContent(newContent);
            _contentRepository.SaveChanges();

            var contentToReturn = _mapper.Map<ContentDto>(newContent);
            return CreatedAtRoute("GetContent", new {id = contentToReturn.Id}, contentToReturn);
        }

        [HttpPut("{idContent}")]
        public ActionResult UpdateContent(int idUser, int idContent, ContentUpdateDto content)
        {
            if (!_contentRepository.UserExists(idUser))
                return NotFound();

            var contentInDB = _contentRepository.GetContentInUser(idUser, idContent);
            if (contentInDB is null)
                return NotFound();

            _mapper.Map(content, contentInDB);
            _contentRepository.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{idContent}")]
        public ActionResult DeleteContent(int idContent)
        {
            if (!_contentRepository.ContentExists(idContent))
                return NotFound();

            var contentToEliminate = _contentRepository.GetContent(idContent);
            if (contentToEliminate is null)
                return NotFound();

            _contentRepository.DeleteContent(contentToEliminate.Id);
            _contentRepository.SaveChanges();

            return NoContent();
        }

        [HttpGet("GetUserTime")]
        public ActionResult GetUsedTime(int idUser)
        {
            if (!_contentRepository.UserExists(idUser))
                return NotFound();

            int time = _contentRepository.UsedTime(idUser);

            return Ok($"Usted ha utilizado {time} minutos en ver contenido");
        }
    }
}
