using AutoMapper;
using InformacionCiudades.API.Models;
using InformacionCiudades.API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Entities = InformacionCiudades.API.Entities;

namespace CityInfo.API.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/ciudades/{idCiudad}/puntosdeinteres")] //Ya que esto es dependiente de ciudades necesito que primero me indique la ciudad
    public class PuntosDeInteresController : ControllerBase
    {
        private readonly IInfoCiudadesRepository _repository;
        private readonly IMapper _mapper;

        public PuntosDeInteresController(IInfoCiudadesRepository repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<PuntoDeInteresDto>> GetPuntosDeInteres(int idCiudad)
        {
            var nombreCiudad = User.Claims.FirstOrDefault(c => c.Type == "city")?.Value;

            if (!_repository.NombreCiudadConcuerdaConIdCiudad(nombreCiudad, idCiudad))
                return Forbid();

            if (!_repository.ExisteCiudad(idCiudad))
                return NotFound();

            return Ok(_mapper.Map<IEnumerable<PuntoDeInteresDto>>(_repository.GetPuntosDeInteresDeCiudad(idCiudad)));
        }

        [HttpGet("{idPuntoDeInteres}", Name = "GetPuntoDeInteres")] // El name se lo da para usarlo en el POST.
        public ActionResult<PuntoDeInteresDto> GetPuntoDeInteres(int idCiudad, int idPuntoDeInteres)
        {
            if (!_repository.ExisteCiudad(idCiudad))
                return NotFound();

            var puntoDeInteres = _repository.GetPuntoDeInteresDeCiudad(idCiudad, idPuntoDeInteres); //Acá lo traemos y no agregamos un método al repositorio pq necesitamos la data, entonces lo tenemos que traer igualmente.

            if (puntoDeInteres == null)
                return NotFound();

            return Ok(_mapper.Map<PuntoDeInteresDto>(puntoDeInteres));
        }

        [HttpPost]
        public ActionResult<PuntoDeInteresDto> CrearPuntoDeInteres(int idCiudad, PuntoDeInteresParaCreacionDto puntoDeInteres)
        {
            if (!_repository.ExisteCiudad(idCiudad))
            {
                return NotFound();
            }

            var nuevoPuntoDeInteres = _mapper.Map<Entities.PuntoDeInteres>(puntoDeInteres);

            _repository.AgregarPuntoDeInteresACiudad(idCiudad, nuevoPuntoDeInteres);
            _repository.GuardarCambios();

            var puntoDeInteresParaDevolver = _mapper.Map<PuntoDeInteresDto>(nuevoPuntoDeInteres);

            return CreatedAtRoute(//CreatedAtRoute es para q devuelva 201, el 200 de post.
                "GetPuntoDeInteres", //El primer parámetro es el Name del endpoint que hace el Get
                new //El segundo los parametros q necesita ese endpoint
                {
                    idCiudad,
                    idPuntoDeInteres = puntoDeInteresParaDevolver.Id
                },
                puntoDeInteresParaDevolver);//El tercero es el objeto creado. 
        }

        [HttpPut("{idPuntoDeInteres}")]
        public ActionResult ActualizarPuntoDeInteres(int idCiudad, int idPuntoDeInteres, PuntoDeInteresParaUpdateDto puntoDeInteres)
        {
            if (!_repository.ExisteCiudad(idCiudad))
                return NotFound();

            var puntoDeInteresEnLaBase = _repository.GetPuntoDeInteresDeCiudad(idCiudad, idPuntoDeInteres);
            if (puntoDeInteresEnLaBase == null)
                return NotFound();

            _mapper.Map(puntoDeInteres, puntoDeInteresEnLaBase); // Ojo que este es distinto.

            _repository.GuardarCambios();

            return NoContent();
        }


        [HttpDelete("{idPuntoDeInteres}")]
        public ActionResult DeletePointOfInterest(int idCiudad, int idPuntoDeInteres)
        {
            if (!_repository.ExisteCiudad(idCiudad))
                return NotFound();

            var puntoDeInteresAEliminar = _repository.GetPuntoDeInteresDeCiudad(idCiudad, idPuntoDeInteres);
            if (puntoDeInteresAEliminar is null)
                return NotFound();

            _repository.EliminarPuntoDeInteres(puntoDeInteresAEliminar);
            _repository.GuardarCambios();

            return NoContent();
        }
    }
}
