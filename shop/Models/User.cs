namespace shop.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; } = string.Empty;
        public byte[] PasswordHash { get; set; } = new byte[32];
        public byte[] PasswordSalt { get; set; } = new byte[32];
        public string? VerificationToken { get; set; }
        public DateTime? VerifiedAt { get; set; }
        public string? PasswordResetToken { get; set; }
        public DateTime? ResetTokenExpires { get; set; }
        

        public ICollection<Review> Reviews { get; set; }
        

        public ICollection<CartItem> CartItems { get; set; }
       

    
        public ICollection<WishlistItem> WishlistItems { get; set; }

        public ICollection<Rating> Ratings { get; set; }

    }
}
