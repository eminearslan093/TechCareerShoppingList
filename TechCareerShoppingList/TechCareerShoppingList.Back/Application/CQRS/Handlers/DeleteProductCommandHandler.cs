using MediatR;
using TechCareerShoppingList.Back.Application.CQRS.Commands;
using TechCareerShoppingList.Back.Application.Interfaces;
using TechCareerShoppingList.Back.Data.Entities;

namespace TechCareerShoppingList.Back.Application.CQRS.Handlers
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommandRequest>
    {
        private readonly IRepository<Product> repository;

        public DeleteProductCommandHandler(IRepository<Product> repository)
        {
            this.repository = repository;
        }

        public async Task<Unit> Handle(DeleteProductCommandRequest request, CancellationToken cancellationToken)
        {
            var deleteEntity = await this.repository.GetByIdAsync(request.Id);
            if (deleteEntity != null)
            {
                await this.repository.RemoveAsync(deleteEntity);
            }
            return Unit.Value;
        }
    }
}