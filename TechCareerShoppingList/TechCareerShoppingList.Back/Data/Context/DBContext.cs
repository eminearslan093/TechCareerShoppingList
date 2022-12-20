using Microsoft.EntityFrameworkCore;
using TechCareerShoppingList.Back.Data.Entities;
using TechCareerShoppingList.Back.Convert;
using System.Reflection.Emit;
using TechCareerShoppingList.Back.Data.Configurations;
using System.Reflection.Metadata;
using TechCareerShoppingList.Back.Data.FakeData;

namespace TechCareerShoppingList.Back.Data.Context
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions<DBContext> options) : base(options)
        {
        }

        //public DbSet<Category>? Categories { get; set; }
        //public DbSet<User>? Users { get; set; }
        //public DbSet<Log>? Logs { get; set; }
        //public DbSet<Role>? Roles { get; set; }
        //public DbSet<Product>? Products { get; set; }
        //public DbSet<Product_ShoppingList>? Product_ShoppingLists { get; set; }
        //public DbSet<ShoppingList>? ShoppingLists { get; set; }

        

        public DbSet<Category> Categories => Set<Category>();//null olm
        public DbSet<User> Users => Set<User>();
        public DbSet<Log> Logs => Set<Log>();
        public DbSet<Role> Roles => Set<Role>();
        public DbSet<Product> Products => Set<Product>(); 
        public DbSet<Product_ShoppingList> Product_ShoppingLists => Set<Product_ShoppingList>();
        public DbSet<ShoppingList> ShoppingLists => Set<ShoppingList>();


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region baziconfigusaryonornekleriFluentApi
            //Fluent api diğer yöntem data annotation
            //modelBuilder.Entity<Category>().ToTable(name: "Category", schema: "dto");
            //bu şekilde tablo adlarını değiştirebiliyoruz yoksa property adı ile tablomuz oluşasacak.

            //modelBuilder.Entity<User>().HasIndex(u => u.Email).IsUnique();
            //modelBuilder.Entity<User>().HasIndex(u => u.Email).IsUnique();
            //modelBuilder.Entity<Log>().Property(p => p.LogTime).HasDefaultValue(true);
            #endregion


            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new LogConfiguration());
            modelBuilder.ApplyConfiguration(new Product_ShoppingListConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfiguration(new ShoppingListConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());



            base.OnModelCreating(modelBuilder);


            /* Fake data Add
             * burada default category ve user eklemeye çalıştım ama olmadı tekrar denenecek ve role ve user da eklenecek
             * 

            modelBuilder.Entity<Category>(b =>
            {
                b.HasData(new
                {
                    Category = new CategoryFake().CategoryDataFake(),
                });

                modelBuilder.Ignore<Category>();
                b.OwnsMany(e => e.Products).HasData(new
                {
                    Product = new ProductFake().ProductDataFake(),
                });
            });
                         */

            /*Default valu
             *Fluent api yöntemi default value verme örnek

            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                modelBuilder.Entity<Context>()
                    .Propery(p => p.IsActive)
                    .HasDefaultValue(true);
            }
            */

            /*Log DatetimeConvert
             * Log tablomda date time türünde property mi eklerken sıkıntı çıkıyordu
             * böyle bir çözüm buldum 
             * ama bunu kullanmaya gerek kalmadı 
             * şimdilik kalsın bura sonra lazım olabilir

            protected override void ConfigureConventions(ModelConfigurationBuilder builder)
            {
                builder.Properties<DateOnly>()
                    .HaveConversion<DateOnlyConverter>()
                    .HaveColumnType("date");
            }
                         */
        }

    }
}
