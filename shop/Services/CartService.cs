using shop.Models;

namespace shop.Services
{
    public class CartService: ICartService
    {
        private List<CartItem> cartItems = new List<CartItem>();

        public List<CartItem> GetCartItems()
        {
            return cartItems;
        }

        public void AddToCart(CartItem item)
        {
            // Check if the item is already in the cart
            var existingItem = cartItems.Find(x => x.ProductId == item.ProductId &&  x.UserId == item.UserId);

            if (existingItem != null)
            {
                // Update the quantity if the item is already in the cart
                existingItem.Quantity += item.Quantity;
            }
            else
            {
                // Add the item to the cart if it's not already present
                item.Price = (decimal)item.Product.Price; // Set the price from the product
                cartItems.Add(item);
            }
        }

        public void UpdateCartItemQuantity(int cartItemId, int newQuantity)
        {
            var existingItem = cartItems.Find(x => x.CartItemId == cartItemId);

            if (existingItem != null)
            {
                existingItem.Quantity = newQuantity;
            }
        }

        public void RemoveFromCart(int cartItemId)
        {
            var itemToRemove = cartItems.Find(x => x.CartItemId == cartItemId);

            if (itemToRemove != null)
            {
                cartItems.Remove(itemToRemove);
            }
        }
    }
}
