using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;
using TechCareerShoppingList.Back.Data.Entities;
using TechCareerShoppingList.Back.Data.FakeData;

namespace TechCareerShoppingList.Back.Data.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {

        public void Configure(EntityTypeBuilder<Category> builder)
        {

            //category adının eşsiz olması ve boş geçemiyeceği ayarı burada yapılacak.Fluent api Daha düzenli 
            //data annotation ile yaptım 


            /*Fake Data
             *             //fake
            //builder.HasData(new CategoryFake().CategoryDataFake());
             */


            #region FakeDataDeneme
            //builder.HasData(new
            //{
            //    Category = new CategoryFake().CategoryDataFake(),
            //});



            //builder.OwnsOne(x => x.Products).HasData(new
            //{
            //    Category = new CategoryFake().CategoryDataFake(),
            //});

            //builder.OwnsOne(x => x.Category).HasData(new
            //{
            //    Product = new CategoryFake().CategoryDataFake(),
            //});


            //builder.OwnsOne<Category>(b =>
            //{
            //    b.HasData(new
            //    {
            //        Category = new CategoryFake().CategoryDataFake(),
            //    });

            //    b.OwnsOne(e => e.Products).HasData(new
            //    {
            //        Product = new ProductFake().ProductDataFake(),
            //    });
            //}); 
            #endregion
        }
    }
}
