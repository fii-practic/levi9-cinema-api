using Levi9.Cinema.Api.Services;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace Levi9.Cinema.Api.Controllers
{
    [Route("api/movies")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieService movieService;

        public MoviesController(IMovieService movieService)
        {
            this.movieService = movieService;
        }

        [HttpGet]
        public IEnumerable<Movie> Get([FromQuery] string? title = null, MovieStatus? status = null)
        {
            return movieService.GetAll(title, status);
        }

        [HttpGet("{id}")]
        public ActionResult<Movie> Get(Guid id)
        {
            var movie = movieService.Get(id);
            return movie;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Movie movie)
        {
            await movieService.Add(movie);
            return CreatedAtAction(nameof(Create), new { id = movie.Id }, movie);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] Movie movie)
        {
            if (id != movie.Id)
                return BadRequest();

            try
            {
                await movieService.Update(movie);
                return NoContent();
            }
            catch (ArgumentNullException)
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                var movie = movieService.Get(id);
                movieService.Delete(id);
                return NoContent();
            }
            catch (ArgumentNullException)
            {
                return NotFound();
            }
        }

        [HttpPatch]
        public async Task<IActionResult> Patch(Guid id, [FromBody] JsonPatchDocument<Movie> patchMovie)
        {
            try
            {
                var existingMovie = movieService.Get(id);
                patchMovie.ApplyTo(existingMovie, ModelState);

                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                await movieService.Update(existingMovie);
                return new ObjectResult(existingMovie);
            }
            catch (ArgumentNullException)
            {
                return NotFound();
            }
        }
    }
}
