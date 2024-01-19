using shop.Models;

namespace shop.Services
{
    public interface IRatingRepository
    {
        Task<IEnumerable<Rating>> GetRatingsByUserIdAsync(int userId);
        Task<IEnumerable<Rating>> GetRatingsByProductIdAsync(int productId);
        Task<Rating> GetRatingAsync(int userId, int productId);
        Task AddRatingAsync(Rating rating);
        Task UpdateRatingAsync(Rating rating);
        Task DeleteRatingAsync(int userId, int productId);
    }
}
