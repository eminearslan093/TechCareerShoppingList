using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TechCareerShoppingList.Back.Data.Entities
{
    public class ShoppingList
    {
        public int Id { get; set; }

        //[Column(TypeName = "nvarchar(50)")]
        //[Required]
        public string? ListName { get; set; }


        public bool State { get; set; }//alışverişe çıkıyorum seçeneği için
        public bool Active { get; set; }// kullanıcı girişini kontrol için, aktif mi değilmi 
        public bool ShoppingOk { get; set; }//alış veriş tamamlandı


 
        public int? UserId { get; set; }
        public  User User { get; set; }
        public  List<Product_ShoppingList> Products_ShoppingList { get; set; }

        public ShoppingList()
        {
            User = new User();
            Products_ShoppingList = new List<Product_ShoppingList>();
        }
    }
}
