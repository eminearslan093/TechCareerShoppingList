using AutoMapper;
using MediatR;
using TechCareerShoppingList.Back.Application.CQRS.Queries;
using TechCareerShoppingList.Back.Application.Dto;
using TechCareerShoppingList.Back.Application.Interfaces;
using TechCareerShoppingList.Back.Data.Entities;

namespace TechCareerShoppingList.Back.Application.CQRS.Handlers
{
    public class GetAllCategoryQueryHandler : IRequestHandler<GetCategoriesQueryRequest, List<CategoryDto>>
    {
        private readonly IRepository<Category> repository;
        private readonly IMapper mapper;

        public GetAllCategoryQueryHandler(IRepository<Category> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<List<CategoryDto>> Handle(GetCategoriesQueryRequest request, CancellationToken cancellationToken)
        {
            var data = await this.repository.GetAllAsync();
            return this.mapper.Map<List<CategoryDto>>(data);
        }
    }
}
