using shop.Models;

namespace shop.Services
{
    public class WishlistService
    {
        private readonly IRepository<WishlistItem> _wishlistRepository;

        public WishlistService(IRepository<WishlistItem> wishlistRepository)
        {
            _wishlistRepository = wishlistRepository;
        }
        public async Task<IEnumerable<WishlistItem>> GetUserWishlistAsync(int userId)
        {
            return await _wishlistRepository.GetAllAsync();
            // You may want to filter by userId here depending on your requirements
        }
        public async Task AddToWishlistAsync(WishlistItem wishlistItem)
        {
            await _wishlistRepository.AddAsync(wishlistItem);
        }
        public async Task RemoveFromWishlistAsync(int wishlistItemId)
        {
            var wishlistItem = await _wishlistRepository.GetByIdAsync(wishlistItemId);
            if (wishlistItem != null)
            {
                await _wishlistRepository.DeleteAsync(wishlistItem);
            }
        }
    }

}
