using shop.Models;

namespace shop.Services
{
    public interface ICategoriesServices
    {
        Task<IEnumerable<Category>> GetAll();
        Task<Category> GetById(int id);
        Task<Category> Add(Category genre);
        Category Update(Category genre);
        Category Delete(Category genre);
        Task<bool> IsvalidGenre(int id);
    }
}
