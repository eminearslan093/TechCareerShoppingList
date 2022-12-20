using MediatR;
using TechCareerShoppingList.Back.Application.Dto;

namespace TechCareerShoppingList.Back.Application.CQRS.Queries
{
    public class GetAllShoppingListQueryRequest: IRequest<List<ShoppingListDto>>
    {
    }
}
