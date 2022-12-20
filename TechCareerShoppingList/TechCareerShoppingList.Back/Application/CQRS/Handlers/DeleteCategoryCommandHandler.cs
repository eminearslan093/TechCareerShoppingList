using MediatR;
using TechCareerShoppingList.Back.Application.CQRS.Commands;
using TechCareerShoppingList.Back.Application.Interfaces;
using TechCareerShoppingList.Back.Data.Entities;

namespace TechCareerShoppingList.Back.Application.CQRS.Handlers
{
    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommandRequest>

    {
        private readonly IRepository<Category> _repository;

        public DeleteCategoryCommandHandler(IRepository<Category> repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(DeleteCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            var deleteEntity = await _repository.GetByIdAsync(request.Id);
            if (deleteEntity != null)
            {
                await _repository.RemoveAsync(deleteEntity);
            }
            return Unit.Value;
        }
    }
}