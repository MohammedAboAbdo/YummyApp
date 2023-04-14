using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YummyApp.Data.Migrations
{
    public partial class SeedChefRoleToId1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "f34ce696-c2d9-4f42-9854-16a02518b04f", "5afdb732-6ff6-4b37-a77f-34596b472e14" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5afdb732-6ff6-4b37-a77f-34596b472e14",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b0a5778d-b953-4ec3-9cc6-05a9e782a57d", "AQAAAAEAACcQAAAAEAqLCS3mhx2dQVx9dHrL/CPmJmDd+Ku4f/GlwwpwQfZcIsh65Bh7U7yBMQ1NjL0YOA==", "a403aa1b-519d-4b41-b8e8-e8c9cdad1a4f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bacbe84a-94e8-418d-8e7d-7fba7cece7a0",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c7c10a6f-b200-4abb-b629-746a6948045a", "AQAAAAEAACcQAAAAEEKlC525mgZfH/5YdSWDamlm4A6EvzYw4Hdqgx2djEtNrtXmUHQvjJHJ4qJXFcwzng==", "e7ce050a-ee81-4723-a828-8342bc999128" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "f34ce696-c2d9-4f42-9854-16a02518b04f", "5afdb732-6ff6-4b37-a77f-34596b472e14" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5afdb732-6ff6-4b37-a77f-34596b472e14",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b63cd41a-00b4-48ff-98f2-356e929f2b53", "AQAAAAEAACcQAAAAEPw90lrKAaQApKu8QKkeUiAfpkFlJv15taS4WtR6QjtO+0FJxxIEIRYym8jrmwXH5A==", "f5645eba-bc78-4c54-99e8-fe43dcc6b923" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bacbe84a-94e8-418d-8e7d-7fba7cece7a0",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "31d34c23-f8c0-4105-bac8-933bbe893280", "AQAAAAEAACcQAAAAECT/NKCcPEqILnp3deZmeOgE19brpOPQq0Sui7laM9eSXLtz1htR6ROZXi+zkbMIGA==", "2cc2fc39-da08-4ae7-be98-90e1fdbcb655" });
        }
    }
}
