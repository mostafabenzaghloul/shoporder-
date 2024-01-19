using shop.Models;

namespace shop.Services
{
    public class WishlistItemRepository : Repository<WishlistItem>
    {
        public WishlistItemRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
