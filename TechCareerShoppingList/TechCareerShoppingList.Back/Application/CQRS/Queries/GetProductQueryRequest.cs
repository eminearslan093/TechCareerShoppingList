using MediatR;
using TechCareerShoppingList.Back.Application.Dto;

namespace TechCareerShoppingList.Back.Application.CQRS.Queries
{
    public class GetProductQueryRequest : IRequest<ProductDto>
    {
        public int Id { get; set; }
        public GetProductQueryRequest(int id)
        {
            Id = id;
        }
    }
}
