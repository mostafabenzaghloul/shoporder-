using shop.Models;

namespace shop.Services
{
    public class OrderDetailService: IOrderDetailServices
    {
        private List<Order> cartItems = new List<Order>();

        public List<Order> GetOrderItems()
        {
            return cartItems;
        }
        public void Add(Order item)
        {
            // Check if the item is already in the cart
            var existingItem = cartItems.Find(x => x.CartItemId == item.CartItemId);         
          
                // Add the item to the cart if it's not already present
                cartItems.Add(item);

        }
    }
}
