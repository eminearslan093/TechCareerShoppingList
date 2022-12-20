using Microsoft.AspNetCore.SignalR;
using TechCareerShoppingList.Back.Data.Entities;

namespace TechCareerShoppingList.Back.Application.Enums
{
    public enum eUserType
    {
        AdminId = 1,
        AdminAdmin,
        admin,//email
        Password = 1,
        RoleId = 1

    }

    //public class GetEnumTitle
    //{
    //    public List<User> GetTitle()
    //    {
    //        List<User> Title = new List<User>()
    //        {
    //          new User(){FullName = eUserType.Admin.ToString()},
             
    //        };
    //        return Title;
    //    }
    //}
}
