namespace shop.Models
{
    public class CartItem
    {
        public int CartItemId { get; set; }
        public int Quantity { get; set; }

        // Foreign Key
        public int ProductId { get; set; }

        // Navigation property
        public Product Product { get; set; }

        public decimal Price { get; set; }
        public decimal Total => Quantity * Price;
        public int UserId { get; set; }
        public User User { get; set; }
        public ICollection<Order> OrderDetail { get; set; }
    }
}
