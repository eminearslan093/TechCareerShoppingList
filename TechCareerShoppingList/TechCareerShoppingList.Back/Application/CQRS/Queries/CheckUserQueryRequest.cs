using MediatR;
using TechCareerShoppingList.Back.Application.Dto;

namespace TechCareerShoppingList.Back.Application.CQRS.Queries
{
    public class CheckUserQueryRequest : IRequest<UserDto>
    {
        public string? Email { get; set; }
        public string? Password { get; set; }

    }
}