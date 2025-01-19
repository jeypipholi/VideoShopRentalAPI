using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VideoShopRentalAPI.Data;
using VideoShopRentalAPI.Models;

namespace VideoShopRentalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;

        public MovieController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult GetAllMovies()
        {
            var allMovies = dbContext.Movies.ToList();

            return Ok(allMovies);
        }

        [HttpGet]
        [Route("(id")]
        public IActionResult GetMovieById(int id)
        {
            var movie = dbContext.Movies.Find(id);

            if (movie is null)
            {
                return NotFound();
            }
            return Ok(movie);
        }


        [HttpPost]
        public IActionResult AddMovie(AddMovieDto addMovieDto)
        {
            var movieEntity = new Movie()
            {
                Title = addMovieDto.Title,
                RentalPrice = addMovieDto.RentalPrice,
            };

            dbContext.Movies.Add(movieEntity);
            dbContext.SaveChanges();
            return Ok(movieEntity);
        }

        [HttpPut]
        [Route("(id")]
        public IActionResult UpdateMovie(int id, UpdateMovieDto updateMovieDto)
        {
            var movie = dbContext.Movies.Find(id);
            if (movie is null)
            {
                return NotFound();
            }

            movie.Title = updateMovieDto.Title;
            movie.RentalPrice = updateMovieDto.RentalPrice;

            dbContext.SaveChanges();
            return Ok(movie);

        }

        [HttpDelete]
        public IActionResult DeleteMovieById(int id)
        {
            var movie = dbContext.Movies.Find(id);
            if (movie is null)
            {
                return NotFound();
            }
            dbContext.Movies.Remove(movie);
            dbContext.SaveChanges();
            return Ok(movie);
        }
    }
}
