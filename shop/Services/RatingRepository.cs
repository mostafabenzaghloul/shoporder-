using Microsoft.EntityFrameworkCore;
using shop.Models;

namespace shop.Services
{
    public class RatingRepository: IRatingRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public RatingRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Rating>> GetRatingsByUserIdAsync(int userId)
        {
            return await _dbContext.rt
                .Where(r => r.UserId == userId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Rating>> GetRatingsByProductIdAsync(int productId)
        {
            return await _dbContext.rt
                .Where(r => r.ProductId == productId)
                .ToListAsync();
        }

        public async Task<Rating> GetRatingAsync(int userId, int productId)
        {
            return await _dbContext.rt
                .FirstOrDefaultAsync(r => r.UserId == userId && r.ProductId == productId);
        }

        public async Task AddRatingAsync(Rating rating)
        {
            _dbContext.rt.Add(rating);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateRatingAsync(Rating rating)
        {
            _dbContext.Entry(rating).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteRatingAsync(int userId, int productId)
        {
            var rating = await GetRatingAsync(userId, productId);
            if (rating != null)
            {
                _dbContext.rt.Remove(rating);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
