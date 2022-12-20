using MediatR;
using TechCareerShoppingList.Back.Application.Dto;

namespace TechCareerShoppingList.Back.Application.CQRS.Queries
{
    public class GetCategoryQueryRequest : IRequest<CategoryDto>
    {
        public int Id { get; set; }

        public GetCategoryQueryRequest(int id)
        {
            Id = id;
        }
    }
}
