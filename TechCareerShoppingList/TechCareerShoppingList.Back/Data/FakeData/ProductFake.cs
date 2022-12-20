using TechCareerShoppingList.Back.Application.Enums;
using TechCareerShoppingList.Back.Data.Entities;

namespace TechCareerShoppingList.Back.Data.FakeData
{
    public class ProductFake
    {
        private readonly Product _product;

        public ProductFake()
        {
            _product = new Product()
            {
                Id =(int) eProductType.ID,
                Name = eProductType.Çilek.ToString(),
                Price =(int) eProductType.Price,
                CategoryId = (int) eProductType.CategoryId
            };
        }

        public Product ProductDataFake()
        {
            return _product;
        }
    }
}
