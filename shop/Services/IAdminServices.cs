using shop.Models;

namespace shop.Services
{
    public interface IAdminServices
    {
        Task<IEnumerable<Admin>> GetAll();
        Task<Admin> GetById(int id);
        Task<Admin> Add(Admin genre);
        Admin Update(Admin genre);
        Admin Delete(Admin genre);
        Task<bool> IsvalidGenre(int id);
        Admin Authenticate(string Email, string Password);
    }
}
