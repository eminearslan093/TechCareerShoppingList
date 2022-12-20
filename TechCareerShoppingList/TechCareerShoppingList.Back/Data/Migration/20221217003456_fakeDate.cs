using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TechCareerShoppingList.Back.Data.Migration
{
    public partial class fakeDate : Microsoft.EntityFrameworkCore.Migrations.Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Meyve" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Definition" },
                values: new object[] { 1, "Admin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
