using AutoMapper;
using MediatR;
using TechCareerShoppingList.Back.Application.CQRS.Queries;
using TechCareerShoppingList.Back.Application.Dto;
using TechCareerShoppingList.Back.Application.Interfaces;
using TechCareerShoppingList.Back.Data.Entities;

namespace TechCareerShoppingList.Back.Application.CQRS.Handlers
{
    public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQueryRequest, List<ProductDto>>//<request,response>
    {
        private readonly IRepository<Product> _repository;
        private readonly IMapper _mapper;

        public GetAllProductsQueryHandler(IRepository<Product> repository, IMapper mapper)
        {
            this._repository = repository;
            this._mapper = mapper;
        }

        public async Task<List<ProductDto>> Handle(GetAllProductsQueryRequest request, CancellationToken cancellationToken)
        {
            //foreach le döndermek yerine  otomatik mapping yapacağız //AUtoMapper.. pacakes
            var data = await this._repository.GetAllAsync();

            return this._mapper.Map<List<ProductDto>>(data);
        }
    }
}
