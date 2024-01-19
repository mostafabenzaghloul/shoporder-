using Microsoft.EntityFrameworkCore;

namespace shop.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        {
        }
        public DbSet<Category>  Categ { get; set; }
        public DbSet<User> us { get; set; }
        public DbSet<Product> prod { get; set; }
        public DbSet<Blog> bl { get; set; }
        public DbSet<Admin> adm { get; set; }
        public DbSet<ResetPasswordRequest> resetPassword { get; set; }
        public DbSet<UserLoginRequest> userLogin { get; set; }
        public DbSet<UserRegisterRequest> userRegister { get; set; }
        public DbSet<Review> rev { get; set; }
        public DbSet<CartItem> ci { get; set; }
        public DbSet<Order> od { get; set; }
        public DbSet<Rating> rt { get; set; }

        public DbSet<WishlistItem> wl { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Review>()
                .HasOne(r => r.Product)
                .WithMany()
                .HasForeignKey(r => r.ProductId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Review>()
              .HasOne(r => r.User)  // Assuming there is a User navigation property in the Review class
              .WithMany()
              .HasForeignKey(r => r.UserId)
              .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<WishlistItem>()
          .HasKey(wi => wi.Id);

            modelBuilder.Entity<WishlistItem>()
                .HasOne(wi => wi.User)
                .WithMany(u => u.WishlistItems)
                .HasForeignKey(wi => wi.UserId);

    ; 

            modelBuilder.Entity<Order>()
               .HasOne(wi => wi.CartItem)
               .WithMany(u => u.OrderDetail)
               .HasForeignKey(wi => wi.CartItemId);

            modelBuilder.Entity<WishlistItem>()
                .HasOne(wi => wi.Product)
                .WithMany(p => p.WishlistItems)
                .HasForeignKey(wi => wi.ProductId);

            modelBuilder.Entity<Rating>()
      .HasKey(r => new { r.UserId, r.ProductId });

            modelBuilder.Entity<Rating>()
                .HasOne(r => r.User)
                .WithMany(u => u.Ratings)
                .HasForeignKey(r => r.UserId);

            modelBuilder.Entity<Rating>()
                .HasOne(r => r.Product)
                .WithMany(p => p.Ratings)
                .HasForeignKey(r => r.ProductId);


        }
    }
}
