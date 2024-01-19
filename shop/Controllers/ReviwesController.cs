using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using shop.Dto;
using shop.Models;
using shop.Services;

namespace shop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviwesController : ControllerBase
    {
        private readonly IReviewRepository _reviewRepository;
        public ReviwesController( IReviewRepository reviewRepository)
        {
           
            _reviewRepository = reviewRepository;           
        }

        [HttpPost("addReview")]
        public async Task<IActionResult> AddReview(int UserId,int productId, [FromBody] ReviewDto reviewDto)
        {

            // Validate and add review to the database
            await _reviewRepository.AddReview(UserId, productId, reviewDto);
            return Ok();
        }

        [HttpGet("pendingReviews")]      
        public async Task<IActionResult> GetPendingReviews()
        {
            var pendingReviews = await _reviewRepository.GetPendingReviews();
            return Ok(pendingReviews);
        }
        [HttpPatch("approveReview/{reviewId}")]
        public async Task<IActionResult> ApproveReview(int reviewId)
        {
            await _reviewRepository.ApproveReview(reviewId);
            return Ok();
        }
    }
}
