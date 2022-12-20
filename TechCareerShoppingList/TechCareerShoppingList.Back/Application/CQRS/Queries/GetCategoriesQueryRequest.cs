using MediatR;
using TechCareerShoppingList.Back.Application.Dto;

namespace TechCareerShoppingList.Back.Application.CQRS.Queries
{
    public class GetCategoriesQueryRequest : IRequest<List<CategoryDto>>
    {
    }
}
