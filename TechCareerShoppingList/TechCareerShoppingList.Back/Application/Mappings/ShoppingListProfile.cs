using AutoMapper;
using TechCareerShoppingList.Back.Application.Dto;
using TechCareerShoppingList.Back.Data.Entities;

namespace TechCareerShoppingList.Back.Application.Mappings
{
    public class ShoppingListProfile : Profile
    {
        public ShoppingListProfile()
        {
            this.CreateMap<ShoppingList, ShoppingListDto>().ReverseMap();
        }
    }
}
