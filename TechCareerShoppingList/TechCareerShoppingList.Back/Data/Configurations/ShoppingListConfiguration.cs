using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using TechCareerShoppingList.Back.Data.Entities;

namespace TechCareerShoppingList.Back.Data.Configurations
{
    public class ShoppingListConfiguration : IEntityTypeConfiguration<ShoppingList>
    {
        public void Configure(EntityTypeBuilder<ShoppingList> builder)
        {
            builder.HasOne(x => x.User)
                  .WithMany(x => x.ShoppingLists)
                  .HasForeignKey(x => x.UserId)
                  .IsRequired();
        }
    }
}
