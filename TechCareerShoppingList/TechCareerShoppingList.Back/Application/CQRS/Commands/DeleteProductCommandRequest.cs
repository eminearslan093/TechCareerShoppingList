using MediatR;

namespace TechCareerShoppingList.Back.Application.CQRS.Commands
{
    public class DeleteProductCommandRequest : IRequest
    {
        public int Id { get; set; }
        public DeleteProductCommandRequest(int id)
        {
            Id = id;
        }
    }
}
