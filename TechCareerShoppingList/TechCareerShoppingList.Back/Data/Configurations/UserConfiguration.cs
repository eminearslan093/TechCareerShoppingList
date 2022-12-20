using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Diagnostics;
using TechCareerShoppingList.Back.Data.Entities;
using TechCareerShoppingList.Back.Data.FakeData;

namespace TechCareerShoppingList.Back.Data.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            //builder.OwnsOne(x => x.Role).HasData(new
            //{
            //    User = new UserFake().UserFakeData(),
            //});

            builder.HasOne(x => x.Role)
                .WithMany(x => x.Users)
                .HasForeignKey((x => x.RoleId))
                .IsRequired();


            //builder.HasData(new UserFake().UserFakeData());

            #region TesttenSonraAc
            //builder.Property(p => p.FullName)
            //    .IsRequired()
            //    .HasMaxLength(100);



            //builder.Property(p => p.Email)
            //    .HasMaxLength(100)
            //    .IsRequired();
            //builder.HasIndex(p => p.Email)
            //    .IsUnique();



            //builder.Property(p => p.Password)
            //    .IsRequired();




            //builder.HasMany(x => x.Logs)
            //    .WithOne(x => x.User)
            //    .HasForeignKey(x => x.UserId)
            //    .IsRequired();


            //builder.HasMany(x => x.ShoppingLists)
            //    .WithOne(x => x.User)
            //    .HasForeignKey(x => x.UserId)
            //    .IsRequired(); 
            #endregion

            #region MyRegion
            //     builder.Entity<User>()
            //.HasRequired<Role>(s => s.CurrentGrade)
            //.WithMany(g => g.Students)
            //.HasForeignKey<int>(s => s.CurrentGradeId);

            //            modelBuilder.Entity<Student>()
            //.HasRequired<Grade>(s => s.CurrentGrade)
            //.WithMany(g => g.Students);



            //protected override void OnModelCreating(ModelBuilder modelBuilder)
            //{
            //    modelBuilder.Entity<User>()
            //    .HasRequired<Role>(r => r.RoleId)
            //    .WithMany(g => g.Students)
            //    .HasForeignKey<int>(s => s.CurrentGradeId);


            //      modelBuilder.Entity<Role>()
            //        .HasMany<User>(g => g.Users)
            //        .HasForeignKey<int>(s => s.CurrentGradeId);

            //}

            // public void Configure(EntityTypeBuilder<User> builder)
            // {
            //     builder.HasOne(x => x.Role)
            //         .WithMany(x => x.Users)
            //         .HasForeignKey(x => x.RoleId);


            //     builder.Entity<User>()
            //.HasRequired<Role>(s => s.CurrentGrade)
            //.WithMany(g => g.Students)
            //.HasForeignKey<int>(s => s.CurrentGradeId);

            //     //            modelBuilder.Entity<Student>()
            //     //.HasRequired<Grade>(s => s.CurrentGrade)
            //     //.WithMany(g => g.Students);

            // } 
            #endregion
        }
    }
}
