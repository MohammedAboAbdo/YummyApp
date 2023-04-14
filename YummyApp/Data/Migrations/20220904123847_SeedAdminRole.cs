using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YummyApp.Data.Migrations
{
    public partial class SeedAdminRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "2a697dda-1c5a-4470-8878-8870d474f66c", "2a697dda-1c5a-4470-8878-8870d474f66c", "Administrator", "ADMINISTRATOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2a697dda-1c5a-4470-8878-8870d474f66c");
        }
    }
}
