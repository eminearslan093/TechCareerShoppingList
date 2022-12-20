using MediatR;
using TechCareerShoppingList.Back.Application.CQRS.Commands;
using TechCareerShoppingList.Back.Application.Enums;
using TechCareerShoppingList.Back.Application.Interfaces;
using TechCareerShoppingList.Back.Data.Entities;

namespace TechCareerShoppingList.Back.Application.CQRS.Handlers
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommandRequest>
    {
        private readonly IRepository<User> _repository;

        public CreateUserCommandHandler(IRepository<User> repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(CreateUserCommandRequest request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new User
            {
                //RoleId = (int)RoleType.Admin,
                RoleId = request.RoleId,
                Password = request.Password,
                FullName = request.FullName,
                Email = request.Email,
            });
            return Unit.Value;
        }
    }
}