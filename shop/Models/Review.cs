namespace shop.Models
{
    public class Review
    {

        public int ReviewId { get; set; }
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string CommentText { get; set; }
        public bool IsApproved { get; set; }
        public DateTime CreatedAt { get; set; }
        public Product Product { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }

    }
}
