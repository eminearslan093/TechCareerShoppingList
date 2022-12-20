using MediatR;

namespace TechCareerShoppingList.Back.Application.CQRS.Commands
{
    public class CreateProductCommandRequest : IRequest
    {
        public string? Name { get; set; } //tek olacak

        public int Price { get; set; }

        public string? ImagePath { get; set; } 

        public int CategoryId { get; set; }
    }
}
