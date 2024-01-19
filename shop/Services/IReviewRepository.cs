using shop.Dto;
using shop.Models;

namespace shop.Services
{
    public interface IReviewRepository
    {
        Task AddReview(int UserId, int productId, ReviewDto reviewDto);
        Task<IEnumerable<Review>> GetPendingReviews();
        Task ApproveReview(int reviewId);
    }
}
