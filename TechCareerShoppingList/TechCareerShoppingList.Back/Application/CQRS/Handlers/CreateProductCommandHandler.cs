using MediatR;
using TechCareerShoppingList.Back.Application.CQRS.Commands;
using TechCareerShoppingList.Back.Application.Interfaces;
using TechCareerShoppingList.Back.Data.Entities;

namespace TechCareerShoppingList.Back.Application.CQRS.Handlers
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommandRequest>
    {
        private readonly IRepository<Product> _repository;

        public CreateProductCommandHandler(IRepository<Product> repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(CreateProductCommandRequest request, CancellationToken cancellationToken)
        {
            try
            {
                await _repository.CreateAsync(new Product
                {
                    CategoryId = request.CategoryId,
                    Name = request.Name,
                    Price = request.Price,
                    ImagePath = request.ImagePath,

                });

                return Unit.Value;

            }
            catch (Exception ex)
            {

                return Unit.Value;
                //return StatusCodes.Status500InternalServerError;
            }
           
        }
    }
}
