

namespace TechCareerShoppingList.Back.Application.Dto
{
    public class ProductDto
    {
        public int Id { get; set; }


        public string? Name { get; set; } 
        public decimal Price { get; set; }

        public string? ImagePath { get; set; }

        public int CategoryId { get; set; }
    }
}
