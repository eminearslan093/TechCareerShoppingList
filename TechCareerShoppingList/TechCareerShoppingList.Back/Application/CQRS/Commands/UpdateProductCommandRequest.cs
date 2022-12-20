using MediatR;

namespace TechCareerShoppingList.Back.Application.CQRS.Commands
{
    public class UpdateProductCommandRequest : IRequest
    {
        public int ID { get; set; }
        public string? Name { get; set; }
        public int Stock { get; set; }
        public int Price { get; set; }
        public int CategoryId { get; set; }
    }
}
