using shop.Models;

namespace shop.Services
{
    public interface ICartService
    {
        public List<CartItem> GetCartItems();
        public void AddToCart(CartItem item);
        public void UpdateCartItemQuantity(int cartItemId, int newQuantity);
        public void RemoveFromCart(int cartItemId);
    }
}
