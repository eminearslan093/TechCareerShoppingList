using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TechCareerShoppingList.Back.Data.Entities
{

    [Index(nameof(Name), IsUnique = true)]//eşşiz olacak
    public class Product
    {

        public int Id { get; set; }


        //[Column(TypeName = "nvarchar(30)")]
        //[Required]
        public string? Name { get; set; } //tek olacak


        public string? ImagePath { get; set; }

        //[Column(TypeName = "decimal(0,0)")]
        public int Price { get; set; }

        public int? CategoryId { get; set; }
        public  Category Category { get; set; }
        public  List<Product_ShoppingList> Product_ShoppingLists { get; set; }
        public Product()
        {
            Category = new Category();
            Product_ShoppingLists = new List<Product_ShoppingList>();
        }
    }
}
