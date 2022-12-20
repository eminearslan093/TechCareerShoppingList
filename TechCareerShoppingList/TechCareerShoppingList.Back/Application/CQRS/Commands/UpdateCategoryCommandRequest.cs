using MediatR;

namespace TechCareerShoppingList.Back.Application.CQRS.Commands
{
    public class UpdateCategoryCommandRequest : IRequest
    {
        public int Id { get; set; }
        public string? Name{ get; set; }
    }
}
