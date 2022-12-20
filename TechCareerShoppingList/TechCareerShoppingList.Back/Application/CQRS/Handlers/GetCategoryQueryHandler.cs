using AutoMapper;
using MediatR;
using TechCareerShoppingList.Back.Application.CQRS.Queries;
using TechCareerShoppingList.Back.Application.Dto;
using TechCareerShoppingList.Back.Application.Interfaces;
using TechCareerShoppingList.Back.Data.Entities;

namespace TechCareerShoppingList.Back.Application.CQRS.Handlers
{
    public class GetCategoryQueryHandler : IRequestHandler<GetCategoryQueryRequest, CategoryDto>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Category> _repository;

        public GetCategoryQueryHandler(IMapper mapper, IRepository<Category> repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<CategoryDto> Handle(GetCategoryQueryRequest request, CancellationToken cancellationToken)
        {
            var data = await this._repository.GetByFilterAsync(x => x.Id == request.Id);
            return this._mapper.Map<CategoryDto>(data);
        }
    }
}
