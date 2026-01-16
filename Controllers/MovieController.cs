using BetaTheaterBE.Model;
using BetaTheaterBE.Service;
using Microsoft.AspNetCore.Mvc;

namespace BetaTheaterBE.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class MovieController : ControllerBase
    {
        private readonly MovieService _movieService;

        public MovieController(MovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpGet]
        public async Task<List<Movie>> Get() =>
            await _movieService.GetAsync();

        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<Movie>> Get(string id)
        {
            var movie = await _movieService.GetAsync(id);

            if (movie is null)
            {
                return NotFound();
            }

            return movie;
        }

        [HttpPost]
        public async Task<IActionResult> Post(Movie newMovie)
        {
            var existing = await _movieService.GetByTitleAsync(newMovie.Title);
            if (existing is not null)
            {
                return Conflict("Movie title already exists.");
            }

            await _movieService.CreateAsync(newMovie);

            return CreatedAtAction(nameof(Get), new { id = newMovie.Id }, newMovie);
        }

        [HttpPatch("{id:length(24)}")]
        public async Task<IActionResult> Update(string id, Movie updatedMovie)
        {
            var movie = await _movieService.GetAsync(id);

            if (movie is null)
            {
                return NotFound();
            }

            updatedMovie.Id = movie.Id;

            var existing = await _movieService.GetByTitleAsync(updatedMovie.Title);
            if (existing is not null && existing.Id != id)
            {
                return Conflict("Movie title already exists.");
            }

            await _movieService.UpdateAsync(id, updatedMovie);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var movie = await _movieService.GetAsync(id);

            if (movie is null)
            {
                return NotFound();
            }

            await _movieService.RemoveAsync(id);

            return NoContent();
        }
    }
}
