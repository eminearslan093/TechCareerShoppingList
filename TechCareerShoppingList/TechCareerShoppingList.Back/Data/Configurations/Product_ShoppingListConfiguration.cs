using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using TechCareerShoppingList.Back.Data.Entities;

namespace TechCareerShoppingList.Back.Data.Configurations
{
    public class Product_ShoppingListConfiguration : IEntityTypeConfiguration<Product_ShoppingList>
    {
        public void Configure(EntityTypeBuilder<Product_ShoppingList> builder)
        {
            //builder.HasKey(x=> new { x.ProductId, x.ShoppingId } );//ikisi birlkte primaey key olmasını istersek

            builder.HasOne(x => x.Product)
              .WithMany(x => x.Product_ShoppingLists)
              .HasForeignKey(x => x.ProductId)
              .IsRequired();


            builder.HasOne(x => x.ShoppingList)
              .WithMany(x => x.Products_ShoppingList)
              .HasForeignKey(x => x.ShoppingId)
              .IsRequired();
        }
    }
}
