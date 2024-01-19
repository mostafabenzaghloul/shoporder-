namespace shop.Models
{
    public class Rating
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }

        public double Value { get; set; }
    }
}
