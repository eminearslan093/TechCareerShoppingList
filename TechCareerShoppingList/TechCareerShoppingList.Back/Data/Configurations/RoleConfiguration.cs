using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TechCareerShoppingList.Back.Data.Entities;
using TechCareerShoppingList.Back.Data.FakeData;

namespace TechCareerShoppingList.Back.Data.Configurations
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            //builder.HasData(new RoleFake().RoleDataFake());
        }
    }
}
