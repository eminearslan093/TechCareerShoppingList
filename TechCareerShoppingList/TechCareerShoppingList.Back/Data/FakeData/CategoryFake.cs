using TechCareerShoppingList.Back.Application.Enums;
using TechCareerShoppingList.Back.Data.Entities;

namespace TechCareerShoppingList.Back.Data.FakeData
{
    public class CategoryFake
    {
        private readonly Category _category;


        public CategoryFake()
        {
            _category = new Category()
            {
                Id = (int)eCategoryType.ID,
                Name = eCategoryType.Meyve.ToString()
            };
        }
        public Category CategoryDataFake()
        {
            return _category;
        }
    }
}
