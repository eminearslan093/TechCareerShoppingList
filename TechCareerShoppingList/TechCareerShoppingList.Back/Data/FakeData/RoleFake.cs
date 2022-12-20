using Microsoft.IdentityModel.Tokens;
using TechCareerShoppingList.Back.Application.Enums;
using TechCareerShoppingList.Back.Data.Entities;

namespace TechCareerShoppingList.Back.Data.FakeData
{
    public class RoleFake
    {
        private readonly Role _role;

        public RoleFake()
        {
            _role = new Role()
            {
                Id =(int) eRoleType.AdminId,
                Definition = eRoleType.Admin.ToString(),
            };
        }
        public Role RoleDataFake()
        {
            return _role;
        }
    }
}
