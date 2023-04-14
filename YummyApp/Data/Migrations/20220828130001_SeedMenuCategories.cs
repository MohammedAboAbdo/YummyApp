using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YummyApp.Data.Migrations
{
    public partial class SeedMenuCategories : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "menuCategories",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Breakfast" });

            migrationBuilder.InsertData(
                table: "menuCategories",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "Lunch" });

            migrationBuilder.InsertData(
                table: "menuCategories",
                columns: new[] { "Id", "Name" },
                values: new object[] { 3, "Dinner" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "menuCategories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "menuCategories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "menuCategories",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
