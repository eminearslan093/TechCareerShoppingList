using AutoMapper;
using TechCareerShoppingList.Back.Application.Dto;
using TechCareerShoppingList.Back.Data.Entities;

namespace TechCareerShoppingList.Back.Application.Mappings
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            //produc productListdto ya çevir ve tersinide yap dedik.
            this.CreateMap<Product, ProductDto>().ReverseMap();
        }
    }
}
