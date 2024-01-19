using System.ComponentModel.DataAnnotations;

namespace shop.Dto
{
    public class CategoriesDto
    {
        public int CatId { get; set; }

        [MaxLength(100)]
        public string Name { get; set; }
        public string Description { get; set; }

    }
}
