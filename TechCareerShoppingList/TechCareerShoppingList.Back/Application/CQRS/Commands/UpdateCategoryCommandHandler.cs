using MediatR;
using TechCareerShoppingList.Back.Application.Interfaces;
using TechCareerShoppingList.Back.Data.Entities;

namespace TechCareerShoppingList.Back.Application.CQRS.Commands
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommandRequest>
    {
        private readonly IRepository<Category> _repository;

        public UpdateCategoryCommandHandler(IRepository<Category> repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(UpdateCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            var updateEntity = await _repository.GetByIdAsync(request.Id);
            if (updateEntity != null)
            {
                updateEntity.Name = request.Name;
                await _repository.UpdateAsync(updateEntity);
            }
            return Unit.Value;

        }
    }
}
