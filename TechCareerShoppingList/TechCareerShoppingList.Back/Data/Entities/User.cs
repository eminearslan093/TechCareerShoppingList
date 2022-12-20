using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Net.Mail;

namespace TechCareerShoppingList.Back.Data.Entities
{
    [Index(nameof(Email), IsUnique = true)]
    public class User
    {
        public int Id { get; set; }

        //[Required]
        public string? FullName { get; set; }


        //[DataType(DataType.EmailAddress)]
        //[Required]//boş geçemez
        public string? Email { get; set; } //tek eşşsiz

        //[Required]
        public string? Password { get; set; }

        public int? RoleId { get; set; }
        public  Role Role { get; set; }
        public  List<ShoppingList> ShoppingLists { get; set; }
        public  List<Log> Logs { get; set; }
        public User()
        {
            Role = new Role();
            ShoppingLists = new List<ShoppingList>();
            Logs = new List<Log>();
        }

    }
}
