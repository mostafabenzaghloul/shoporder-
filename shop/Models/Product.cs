using System.ComponentModel.DataAnnotations;

namespace shop.Models
{
    public class Product
    {

        public int Id { get; set; }

        [MaxLength(250)]

        public string Title { get; set; }

        public double? Rate { get; set; }
        public double? Price { get; set; }


        [MaxLength(2500)]
        public string? Descreption { get; set; }

        public byte[] Poster { get; set; }
        public int ReviewId { get; set; }

        public ICollection<Review> Reviews { get; set; }
        public int CategoryId { get; set; }

        public Category Category { get; set; }
        public ICollection<WishlistItem> WishlistItems { get; set; }
        public ICollection<Rating> Ratings { get; set; }



        public static implicit operator Product(Task<Product> v)
        {
            throw new NotImplementedException();
        }
    }
}
