using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using shop.Models;
using shop.Services;

namespace shop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartService _cartService;
        private readonly IProductsServices _productService;
        public CartController(ICartService cartService, IProductsServices productService)
        {
            _cartService = cartService;
            _productService = productService;
        }

        [HttpGet]
        public IActionResult GetOrderItems()
        {
            var cartItems = _cartService.GetCartItems();
            return Ok(cartItems.Select(item => new
            {
                item.CartItemId,
                item.Quantity,
                item.ProductId,
                item.UserId,
                item.User.Email,
                item.User,
                item.Product.Title,               
                item.Price,
                item.Total
            }));
        }

        [HttpPost]
        public IActionResult AddToCart([FromBody] CartItem item)
        {
            var product = _productService.GetById(item.ProductId);

            if (product == null)
            {
                return NotFound("Product not found");
            }

            item.Product = product;

            _cartService.AddToCart(item);
            return Ok();
        }
        [HttpPut("{cartItemId}")]
        public IActionResult UpdateCartItemQuantity(int cartItemId, [FromBody] int newQuantity)
        {
            _cartService.UpdateCartItemQuantity(cartItemId, newQuantity);
            return Ok();
        }
        [HttpDelete("{cartItemId}")]
        public IActionResult RemoveFromCart(int cartItemId)
        {
            _cartService.RemoveFromCart(cartItemId);
            return Ok();
        }
    }
}
