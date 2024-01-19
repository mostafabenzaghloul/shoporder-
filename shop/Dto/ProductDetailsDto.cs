namespace shop.Dto
{
    public class ProductDetailsDto
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public int Year { get; set; }

        public double Rate { get; set; }

        public double Price { get; set; }

        public string Descreption { get; set; }

        public byte[] Poster { get; set; }

        public int CategoryId { get; set; }

        public string GenreName { get; set; }
    }
}
