using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using shop.Models;
using shop.Services;

namespace shop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly ICartService _cartService;
        private readonly IOrderDetailServices _productService;
        public OrdersController(ICartService cartService, IOrderDetailServices productService)
        {
            _cartService = cartService;
            _productService = productService;
        }
        [HttpGet]
        public IActionResult GetCartItems()
        {
            var cartItems = _productService.GetOrderItems();
            return Ok(cartItems.Select(item => new
            {
                item.Id,
                item.FirstName,
                item.LastName,
                item.CartItem.CartItemId,
                item.CartItem,
                item.Country,
                item.Street,
                item.Adress,
                item.City,
                item.Region,
                item.PostalCode,
                item.Phone,
                item.Email,
                item.Notes
              
            }));
           
        }
        [HttpPost("addOrderDetail")]
        public IActionResult AddOrderDetail([FromBody] Order orderDetail)
        {
            try
            {
                _productService.Add(orderDetail);
                return Ok("OrderDetail added successfully");
            }
            catch (Exception ex)
            {
                // Log the exception or handle it accordingly
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }

    }
}
