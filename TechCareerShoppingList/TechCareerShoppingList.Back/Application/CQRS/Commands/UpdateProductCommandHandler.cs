using MediatR;
using TechCareerShoppingList.Back.Application.Interfaces;
using TechCareerShoppingList.Back.Data.Entities;

namespace TechCareerShoppingList.Back.Application.CQRS.Commands
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommandRequest>
    {
        private readonly IRepository<Product> _repository;

        public UpdateProductCommandHandler(IRepository<Product> repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(UpdateProductCommandRequest request, CancellationToken cancellationToken)
        {
            var updateProdduct = await _repository.GetByIdAsync(request.ID);
            if (updateProdduct != null)
            {
                updateProdduct.CategoryId = request.CategoryId;
                //updateProdduct.Stock = request.Stock;
                updateProdduct.Price = request.Price;
                updateProdduct.Name = request.Name;
            }
            return Unit.Value;
        }
    }
}