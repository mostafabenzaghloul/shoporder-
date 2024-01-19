using shop.Models;

namespace shop.Services
{
    public interface IProductsServices
    {
        Task<IEnumerable<Product>> GetAll(int genreId = 0);
        Task<Product> GetById(int id);
        Task<Product> Add(Product movie);
        Product Update(Product movie);
        Product Delete(Product movie);
    }
}
