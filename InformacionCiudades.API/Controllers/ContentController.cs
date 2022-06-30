using AutoMapper;
using Contents.API.Models;
using Contents.API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Contents.API.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/ciudades")]
    public class ContentController : ControllerBase
    {
        //private readonly CiudadesData _ciudadesData;
        private readonly IContentRepository _contentRepository;
        private readonly IMapper _mapper;

        public ContentController(IContentRepository contentRepository, IMapper mapper)
        {
            //_ciudadesData = ciudadesData;
            _contentRepository = contentRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ContentDto>> GetContents() //JsonResults implementa IActionResults
        {
            var contents = _contentRepository.GetContents();

            /*var resultados = new List<CiudadSinPuntosDeInteresDto>();

            foreach (var ciudad in ciudades)
            {
                resultados.Add(new CiudadSinPuntosDeInteresDto {
                    Id = ciudad.Id,
                    Descripcion = ciudad.Descripcion,
                    Nombre = ciudad.Nombre
                });
            }*/ //Esto ya no lo usamos porque ahora todo ese trabajo lo hace automapper.

            return Ok(_mapper.Map<IEnumerable<ContentDto>>(contents));

            //return Ok(_ciudadesData.Ciudades);
        }

        [HttpGet("{id}")]
        public IActionResult GetCiudad(int id) //Ahora devolvemos un IActionResult para que sea más genérico, ya que ahora podemos devolver CiudadDto o CiudadSinPuntosDeInteresDto
                                                                                    //incluirPuntosDeInteres se envía como parámetro en la url al final de la misma de la siguiente manera /api/ciudades/1?incluirPuntosDeInteres=true
        {
            var content = _contentRepository.GetContent(id);
            if (content == null)
                return NotFound();

            return Ok(_mapper.Map<ContentDto>(content));
        }
    }
}
