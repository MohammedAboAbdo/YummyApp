using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YummyApp.Data.Migrations
{
    public partial class seedadminuser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Desc", "Email", "EmailConfirmed", "FirstName", "ImageName", "JobTitle", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "userType" },
                values: new object[] { "bacbe84a-94e8-418d-8e7d-7fba7cece7a0", 0, "9b5643a2-85fd-43e8-bc4f-a1e1550adb94", null, "admin@admin.com", false, "Admin", null, null, "Admin", false, null, "ADMIN@ADMIN.COM", null, "AQAAAAEAACcQAAAAEF/0f5muj+LzgNTeo02LOZ5C0FS3mHiIKzFOO1CNZYnDTcsh3ay22V5Fdj6y1Yth7Q==", null, false, "46525667-b577-4dbd-8135-0aff7479d999", false, "Admin", "Administrator" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bacbe84a-94e8-418d-8e7d-7fba7cece7a0");
        }
    }
}
