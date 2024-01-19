using Microsoft.EntityFrameworkCore;
using shop.Models;

namespace shop.Services
{
    public class PoductsServices:IProductsServices
    {
        private readonly ApplicationDbContext _context;
        private readonly IReviewRepository _reviewRepository;

        public PoductsServices(ApplicationDbContext context , IReviewRepository reviewRepository)
        {
            _context = context;
            _reviewRepository = reviewRepository;
        }


        public async Task<Product> Add(Product movie)
        {
            await _context.AddAsync(movie);
            _context.SaveChanges();

            return movie;
        }

        public Product Delete(Product movie)
        {
            _context.Remove(movie);
            _context.SaveChanges();

            return movie;
        }

        public async Task<IEnumerable<Product>> GetAll(int genreId = 0)
        {
            return await _context.prod
                .Where(m => m.CategoryId == genreId || genreId == 0)
                .OrderByDescending(m => m.Rate)
                .Include(m => m.Category)
                .ToListAsync();
        }

        public async Task<Product> GetById(int productId)
        {
            var product = await _context.prod
            .Include(p => p.Reviews).Include(m => m.Category)         
            .FirstOrDefaultAsync(p => p.Id == productId);
           
            if (product != null)
            {
                // Include approved reviews for the product
                product.Reviews = product.Reviews.Where(r => r.IsApproved).ToList();                // Include comments for the product
               
            }
            return product;
        }

        public Product Update(Product movie)
        {
            _context.Update(movie);
            _context.SaveChanges();

            return movie;
        }
    }
}
