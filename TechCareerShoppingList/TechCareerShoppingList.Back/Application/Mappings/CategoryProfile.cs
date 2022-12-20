using AutoMapper;
using TechCareerShoppingList.Back.Application.Dto;
using TechCareerShoppingList.Back.Data.Entities;

namespace TechCareerShoppingList.Back.Application.Mappings
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<Category, CategoryDto>().ReverseMap();
        }
    }
}
