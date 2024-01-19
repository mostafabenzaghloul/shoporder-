using System.ComponentModel.DataAnnotations;

namespace shop.Dto
{
    public class ProductDto
    {
        [MaxLength(250)]

        public string Title { get; set; }

        public double? Rate { get; set; }
        public double? Price { get; set; }

        [MaxLength(2500)]
        public string? Descreption { get; set; }

        public IFormFile? Poster { get; set; }

        public int CategoryId { get; set; }
    }
}
