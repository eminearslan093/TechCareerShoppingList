using AutoMapper;
using MediatR;
using TechCareerShoppingList.Back.Application.CQRS.Queries;
using TechCareerShoppingList.Back.Application.Dto;
using TechCareerShoppingList.Back.Application.Interfaces;
using TechCareerShoppingList.Back.Data.Entities;

namespace TechCareerShoppingList.Back.Application.CQRS.Handlers
{
    public class GetAllShoppingListQueryHandler : IRequestHandler<GetAllShoppingListQueryRequest, List<ShoppingListDto>>
    {
        private readonly IRepository<ShoppingList> _repository;
        private readonly IMapper _mapper;

        public GetAllShoppingListQueryHandler(IRepository<ShoppingList> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<ShoppingListDto>> Handle(GetAllShoppingListQueryRequest request, CancellationToken cancellationToken)
        {
            var data = await this._repository.GetAllAsync();
            return this._mapper.Map<List<ShoppingListDto>>(data);
        }
    }
}
