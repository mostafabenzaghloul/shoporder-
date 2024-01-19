using System.ComponentModel.DataAnnotations;

namespace shop.Models
{
    public class Category
    {

        public int Id { get; set; }
        [MaxLength(100)]
        public string? Name { get; set; }
        public string? Description { get; set; }
      
    }
}
