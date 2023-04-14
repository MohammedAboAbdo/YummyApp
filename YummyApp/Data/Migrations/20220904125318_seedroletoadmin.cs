using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YummyApp.Data.Migrations
{
    public partial class seedroletoadmin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "2a697dda-1c5a-4470-8878-8870d474f66c", "bacbe84a-94e8-418d-8e7d-7fba7cece7a0" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bacbe84a-94e8-418d-8e7d-7fba7cece7a0",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "af43d3e1-b540-41ce-95f1-ea9f759f493f", "AQAAAAEAACcQAAAAEI57htN9NjcKPKZdsWfwXXFSfn4KIiZIoMikD/HZ4N+pOSEatTbsHxBjEQTcI3ooTQ==", "3b8c99cb-3297-4741-9984-c3e110de80a9" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "2a697dda-1c5a-4470-8878-8870d474f66c", "bacbe84a-94e8-418d-8e7d-7fba7cece7a0" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bacbe84a-94e8-418d-8e7d-7fba7cece7a0",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9b5643a2-85fd-43e8-bc4f-a1e1550adb94", "AQAAAAEAACcQAAAAEF/0f5muj+LzgNTeo02LOZ5C0FS3mHiIKzFOO1CNZYnDTcsh3ay22V5Fdj6y1Yth7Q==", "46525667-b577-4dbd-8135-0aff7479d999" });
        }
    }
}
