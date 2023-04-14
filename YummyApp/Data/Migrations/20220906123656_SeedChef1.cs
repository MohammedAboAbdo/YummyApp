using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YummyApp.Data.Migrations
{
    public partial class SeedChef1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bacbe84a-94e8-418d-8e7d-7fba7cece7a0",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "31d34c23-f8c0-4105-bac8-933bbe893280", "AQAAAAEAACcQAAAAECT/NKCcPEqILnp3deZmeOgE19brpOPQq0Sui7laM9eSXLtz1htR6ROZXi+zkbMIGA==", "2cc2fc39-da08-4ae7-be98-90e1fdbcb655" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Desc", "Email", "EmailConfirmed", "FirstName", "ImageName", "JobTitle", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "userType" },
                values: new object[] { "5afdb732-6ff6-4b37-a77f-34596b472e14", 0, "b63cd41a-00b4-48ff-98f2-356e929f2b53", null, "chef1@chef.com", false, "Mohammed", null, null, "Abdo", false, null, "CHEF1@CHEF.COM", "CHEF1", "AQAAAAEAACcQAAAAEPw90lrKAaQApKu8QKkeUiAfpkFlJv15taS4WtR6QjtO+0FJxxIEIRYym8jrmwXH5A==", null, false, "f5645eba-bc78-4c54-99e8-fe43dcc6b923", false, "CHEF1", "Chef" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5afdb732-6ff6-4b37-a77f-34596b472e14");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bacbe84a-94e8-418d-8e7d-7fba7cece7a0",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "af43d3e1-b540-41ce-95f1-ea9f759f493f", "AQAAAAEAACcQAAAAEI57htN9NjcKPKZdsWfwXXFSfn4KIiZIoMikD/HZ4N+pOSEatTbsHxBjEQTcI3ooTQ==", "3b8c99cb-3297-4741-9984-c3e110de80a9" });
        }
    }
}
