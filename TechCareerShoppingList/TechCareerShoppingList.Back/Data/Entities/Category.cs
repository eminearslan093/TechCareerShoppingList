using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TechCareerShoppingList.Back.Data.Entities
{

    //[Index(nameof(Name), IsUnique = true)]
    public class Category
    {
        public int Id { get; set; }



        //[Column(TypeName = "nvarchar(30)")]
        //[Required]
        public string? Name { get; set; }

        public  List<Product> Products { get; set; }
        public Category()
        {
            Products = new List<Product>();
        }
    }
}
