using Microsoft.EntityFrameworkCore;
using shop.Models;

namespace shop.Services
{
    public class AdminsServices:IAdminServices
    {
        private readonly ApplicationDbContext _context;

        public AdminsServices(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Admin> Add(Admin genre)
        {
            await _context.AddAsync(genre);
            _context.SaveChanges();

            return genre;
        }

        public Admin Delete(Admin genre)
        {
            _context.Remove(genre);
            _context.SaveChanges();

            return genre;
        }

        public async Task<IEnumerable<Admin>> GetAll()
        {
            return await _context.adm.OrderBy(g => g.name).ToListAsync();
        }

        public async Task<Admin> GetById(int id)
        {
            return await _context.adm.SingleOrDefaultAsync(g => g.Id == id);
        }

        public Task<bool> IsvalidGenre(int id)
        {
            return _context.adm.AnyAsync(g => g.Id == id);
        }

        public Admin Update(Admin genre)
        {
            _context.Update(genre);
            _context.SaveChanges();

            return genre;
        }
        public Admin Authenticate(string Email, string Password)
        {
            // Replace this with your actual logic to retrieve the user from the database
            return  _context.adm.SingleOrDefault(u => u.Email == Email && u.Password == Password);
        }
    }
}
