using MediatR;

namespace TechCareerShoppingList.Back.Application.CQRS.Commands
{
    public class DeleteCategoryCommandRequest : IRequest
    {
        public DeleteCategoryCommandRequest(int id)
        {
            Id = id;

        }

        public int Id { get; set; }
        public string? Name { get; set; }
    }
}
