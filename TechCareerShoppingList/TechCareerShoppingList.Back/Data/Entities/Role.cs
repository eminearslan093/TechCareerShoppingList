using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace TechCareerShoppingList.Back.Data.Entities
{

    [Index(nameof(Definition), IsUnique = true)]
    public class Role
    {
        public int Id { get; set; }

        //[Column(TypeName = "nvarchar(30)")]
        //[Required]
        public string? Definition { get; set; }

        public  List<User> Users { get; set; }

        public Role()
        {
            Users = new List<User>();
        }
    }
}
