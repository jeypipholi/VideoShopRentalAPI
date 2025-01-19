using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using VideoShopRentalAPI.Data;
using VideoShopRentalAPI.Models;

namespace VideoShopRentalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentalHeaderController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;

        public RentalHeaderController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpPost("rent")]
        public async Task<IActionResult> RentMovies([FromBody] RentMoviesRequest rentMoviesRequest)
        {
           var rentalHeader = new List<RentalHeader>();

            foreach (var moviId in rentMoviesRequest.MovieIds)
            {
                var rental = new RentalHeader
                {
                    CustomerId = rentMoviesRequest.CustomerId,
                    MovieId = moviId,
                    RentalStart = DateTime.UtcNow,
                    RentalEnd = DateTime.UtcNow.AddDays(rentMoviesRequest.RentalDuration),
                    RentalDuration = rentMoviesRequest.RentalDuration,
                };
                rentalHeader.Add(rental);
            }
            await dbContext.RentalHeaders.AddRangeAsync(rentalHeader);
            await dbContext.SaveChangesAsync();
            return Ok("Movies Rented successfully");
        }

        [HttpPost("return")]
        public async Task<IActionResult> ReturnMovies([FromBody] ReturnMovieRequest request)
        {
            foreach (var rentalId in request.RentalIds)
            {
                var rental = await dbContext.RentalHeaders.FindAsync(rentalId);
                if (rental == null)
                {
                    return BadRequest($"Rental with ID {rentalId} not found.");
                }

                rental.RentalEnd = DateTime.UtcNow;
               
            }
            await dbContext.SaveChangesAsync();
            return Ok("Movies returned successfully.");
        }
    }
}
