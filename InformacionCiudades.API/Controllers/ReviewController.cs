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
    [Route("api/reviews")]
    public class ReviewController : ControllerBase
    {
        private readonly IContentRepository _contentRepository;
        private readonly IMapper _mapper;

        public ReviewController(IContentRepository contentRepository, IMapper mapper)
        {
            _contentRepository = contentRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ReviewDto>> GetReviews() //JsonResults implementa IActionResults
        {
            var reviews = _contentRepository.GetReviews();

            return Ok(_mapper.Map<IEnumerable<ReviewDto>>(reviews));

        }

        [HttpGet("{id}", Name = "GetReview")]
        public IActionResult GetReview(int id) //Ahora devolvemos un IActionResult para que sea más genérico, ya que ahora podemos devolver CiudadDto o CiudadSinPuntosDeInteresDto
                                                //incluirPuntosDeInteres se envía como parámetro en la url al final de la misma de la siguiente manera /api/ciudades/1?incluirPuntosDeInteres=true
        {
            var review = _contentRepository.GetReview(id);
            if (review == null)
                return NotFound();


            return Ok(_mapper.Map<ReviewDto>(review));
        }
        [HttpPost]
        public ActionResult<ReviewDto> CreateReview(int idContent, ReviewCreationDto reviewRequestBody)
        {
            if (!_contentRepository.ContentExists(idContent))
            {
                return NotFound();
            }

            if (reviewRequestBody.Title == "" || reviewRequestBody.Comment == "")
            {
                return BadRequest();
            }
            var newReview = _mapper.Map<Review>(reviewRequestBody);
            int userId = Int32.Parse(HttpContext.User.Claims.FirstOrDefault(x => x.Type.Contains("nameidentifier")).Value);
            newReview.UserId = userId;
            _contentRepository.AddReviewToContent(idContent, newReview);
            _contentRepository.SaveChanges();
            var reviewToReturn = _mapper.Map<ReviewDto>(newReview);
            return CreatedAtRoute("GetReview", new { id = reviewToReturn.Id }, reviewToReturn);
        }

        [HttpPut("{idReview}")]
        public ActionResult UpdateReview(int idContent, int idReview, ReviewUpdateDto review)
        {
            if (!_contentRepository.ContentExists(idContent))
                return NotFound();

            var reviewInDB = _contentRepository.GetReviewInContent(idContent, idReview);
            if (reviewInDB is null)
                return NotFound();

            _mapper.Map(review, reviewInDB);
            _contentRepository.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{idReview}")]
        public ActionResult DeleteReview(int idReview)
        {
            if (!_contentRepository.ReviewExists(idReview))
                return NotFound();

            var reviewToEliminate = _contentRepository.GetReview(idReview);
            if (reviewToEliminate is null)
                return NotFound();

            _contentRepository.DeleteReview(reviewToEliminate.Id);
            _contentRepository.SaveChanges();

            return NoContent();
        }
    }
}
