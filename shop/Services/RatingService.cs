using shop.Models;

namespace shop.Services
{
    public class RatingService
    {
        private readonly IRatingRepository _ratingRepository;

        public RatingService(IRatingRepository ratingRepository)
        {
            _ratingRepository = ratingRepository;
        }

        public async Task<IEnumerable<Rating>> GetRatingsByUserIdAsync(int userId)
        {
            return await _ratingRepository.GetRatingsByUserIdAsync(userId);
        }

        public async Task<IEnumerable<Rating>> GetRatingsByProductIdAsync(int productId)
        {
            return await _ratingRepository.GetRatingsByProductIdAsync(productId);
        }

        public async Task<Rating> GetRatingAsync(int userId, int productId)
        {
            return await _ratingRepository.GetRatingAsync(userId, productId);
        }

        public async Task AddRatingAsync(Rating rating)
        {
            await _ratingRepository.AddRatingAsync(rating);
        }

        public async Task UpdateRatingAsync(Rating rating)
        {
            await _ratingRepository.UpdateRatingAsync(rating);
        }

        public async Task DeleteRatingAsync(int userId, int productId)
        {
            await _ratingRepository.DeleteRatingAsync(userId, productId);
        }
    }
}
