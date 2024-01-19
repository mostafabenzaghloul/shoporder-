using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using shop.Models;
using shop.Services;

namespace shop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WishlistController : ControllerBase
    {
        private readonly WishlistService _wishlistService;

        public WishlistController(WishlistService wishlistService)
        {
            _wishlistService = wishlistService;
        }
        [HttpGet("{userId}")]
        public async Task<ActionResult<IEnumerable<WishlistItem>>> GetUserWishlist(int userId)
        {
            var wishlist = await _wishlistService.GetUserWishlistAsync(userId);
            return Ok(wishlist);
        }
        [HttpPost]
        public async Task<ActionResult> AddToWishlist([FromBody] WishlistItem wishlistItem)
        {
            await _wishlistService.AddToWishlistAsync(wishlistItem);
            return Ok();
        }
        [HttpDelete("{wishlistItemId}")]
        public async Task<ActionResult> RemoveFromWishlist(int wishlistItemId)
        {
            await _wishlistService.RemoveFromWishlistAsync(wishlistItemId);
            return Ok();
        }
    }
}
