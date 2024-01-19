using Microsoft.EntityFrameworkCore;
using shop.Dto;
using shop.Models;

namespace shop.Services
{
    public class ReviewRepository: IReviewRepository
    {
        private readonly ApplicationDbContext _context;

        public ReviewRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddReview(int UserId,int productId, ReviewDto reviewDto)
        {
            var review = new Review
            {
                UserId=UserId,  
                ProductId = productId,
                Name = reviewDto.Name,
                CommentText = reviewDto.CommentText,
                CreatedAt = DateTime.Now
            };
            _context.rev.Add(review);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Review>> GetPendingReviews()
        {
            return await _context.rev
                .Where(r => !r.IsApproved)
                .ToListAsync();
        }

        public async Task ApproveReview(int reviewId)
        {
            var review = await _context.rev.FindAsync(reviewId);

            if (review != null)
            {
                review.IsApproved = true;
                await _context.SaveChangesAsync();
            }
        }
    }
}

