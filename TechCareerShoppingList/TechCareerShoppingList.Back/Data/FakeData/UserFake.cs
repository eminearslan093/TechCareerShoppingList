using TechCareerShoppingList.Back.Application.Enums;
using TechCareerShoppingList.Back.Data.Entities;

namespace TechCareerShoppingList.Back.Data.FakeData
{
    public class UserFake
    {
        private readonly User _user;

        public UserFake()
        {
            _user = new User()
            {
                FullName = eUserType.AdminAdmin.ToString(),
                Email = eUserType.admin.ToString()+"@"+ eUserType.admin.ToString(),
                Password = eUserType.Password.ToString(),
                 RoleId = (int)eUserType.RoleId
            };
        }

        public User UserFakeData()
        {
            return _user;
        } 
    }
}
