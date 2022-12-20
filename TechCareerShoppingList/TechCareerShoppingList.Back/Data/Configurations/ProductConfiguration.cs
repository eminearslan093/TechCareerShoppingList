using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using TechCareerShoppingList.Back.Data.Entities;
using TechCareerShoppingList.Back.Data.FakeData;
using System.Reflection.Emit;

namespace TechCareerShoppingList.Back.Data.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {


            builder.HasOne(x => x.Category)
            .WithMany(x => x.Products)
            .HasForeignKey(x => x.CategoryId)
            .IsRequired();

            //builder.HasData(new ProductFake().ProductDataFake());
            //builder.Ignore<Product>();
            //builder.OwnsOne(x => x.Category).HasData(new
            //{
            //    Product = new ProductFake().ProductDataFake(),
            //});


            //builder.OwnsOne(x=> x.Category).HasData(new
            //{
            //    Product = new ProductFake().ProductDataFake(),
            //});

            //builder.HasData(new ProductFake().ProductDataFake());
        }
    }
}
