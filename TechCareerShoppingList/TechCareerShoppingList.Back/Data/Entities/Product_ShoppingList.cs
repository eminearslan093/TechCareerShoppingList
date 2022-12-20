using System.ComponentModel.DataAnnotations.Schema;

namespace TechCareerShoppingList.Back.Data.Entities
{
    public class Product_ShoppingList
    {
        public int Id { get; set; }

        public int? ProductId { get; set; }


        public int? ShoppingId { get; set; }

        public  Product Product { get; set; }
        public  ShoppingList ShoppingList { get; set; }

        public Product_ShoppingList()
        {
            Product = new Product();
            ShoppingList = new ShoppingList();
        }
    }
}
