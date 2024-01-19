using Microsoft.EntityFrameworkCore;
using shop.Models;

namespace shop.Services
{
    public class CategoriesServices:ICategoriesServices
    {
        private readonly ApplicationDbContext _context;

        public CategoriesServices(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Category> Add(Category genre)
        {
            await _context.AddAsync(genre);
            _context.SaveChanges();

            return genre;
        }

        public Category Delete(Category genre)
        {
            _context.Remove(genre);
            _context.SaveChanges();

            return genre;
        }

        public async Task<IEnumerable<Category>> GetAll()
        {
            return await _context.Categ.OrderBy(g => g.Name).ToListAsync();
        }

        public async Task<Category> GetById(int id)
        {
            return await _context.Categ.SingleOrDefaultAsync(g => g.Id == id);
        }

        public Task<bool> IsvalidGenre(int id)
        {
            return _context.Categ.AnyAsync(g => g.Id == id);
        }

        public Category Update(Category genre)
        {
            _context.Update(genre);
            _context.SaveChanges();

            return genre;
        }
    }
}
