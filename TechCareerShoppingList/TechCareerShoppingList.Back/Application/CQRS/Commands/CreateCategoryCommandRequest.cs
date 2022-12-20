using MediatR;

namespace TechCareerShoppingList.Back.Application.CQRS.Commands
{
    public class CreateCategoryCommandRequest : IRequest
    {
        public string? Name { get; set; }
    }
}
