using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using shop.Models;
using shop.Services;

namespace shop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RatingController : ControllerBase
    {
        private readonly RatingService _ratingService;

        public RatingController(RatingService ratingService)
        {
            _ratingService = ratingService;
        }

        [HttpGet("user/{userId}")]
        public async Task<ActionResult<IEnumerable<Rating>>> GetRatingsByUserId(int userId)
        {
            var ratings = await _ratingService.GetRatingsByUserIdAsync(userId);
            return Ok(ratings);
        }

        [HttpGet("product/{productId}")]
        public async Task<ActionResult<IEnumerable<Rating>>> GetRatingsByProductId(int productId)
        {
            var ratings = await _ratingService.GetRatingsByProductIdAsync(productId);
            return Ok(ratings);
        }

        [HttpGet("{userId}/{productId}")]
        public async Task<ActionResult<Rating>> GetRating(int userId, int productId)
        {
            var rating = await _ratingService.GetRatingAsync(userId, productId);
            if (rating == null)
                return NotFound();

            return Ok(rating);
        }

        [HttpPost]
        public async Task<ActionResult> AddRating(Rating rating)
        {
            await _ratingService.AddRatingAsync(rating);
            return CreatedAtAction(nameof(GetRating), new { userId = rating.UserId, productId = rating.ProductId }, rating);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateRating(Rating rating)
        {
            await _ratingService.UpdateRatingAsync(rating);
            return NoContent();
        }

        [HttpDelete("{userId}/{productId}")]
        public async Task<ActionResult> DeleteRating(int userId, int productId)
        {
            await _ratingService.DeleteRatingAsync(userId, productId);
            return NoContent();
        }
    }
}
