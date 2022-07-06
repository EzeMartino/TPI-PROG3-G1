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

        [HttpGet("{id}")]
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
            if (!_contentRepository.ExisteUser(idUser))
            {
                return NotFound();
            }
            
            if (contentRequestBody.Title == null || contentRequestBody.Title == "" || contentRequestBody.Duration == null || contentRequestBody.Duration == 0 || contentRequestBody.Comment == null || contentRequestBody.Comment == "" || contentRequestBody.Category == null)
            {
                return NotFound();
            }
            var newContent = _mapper.Map<Content>(contentRequestBody);
            _contentRepository.AgregarContentAUser(idUser, newContent);
            _contentRepository.CreateContent(newContent);
            _contentRepository.SaveChanges();

            var contentToReturn = _mapper.Map<ContentDto>(newContent);
            return CreatedAtRoute("CreateContent", new {idUser, idContent=contentToReturn.Id},contentToReturn);
        }
    }
}
