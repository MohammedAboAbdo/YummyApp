using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YummyApp.Data.Migrations
{
    public partial class adddatetoeventtb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "EventDate",
                table: "events",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5afdb732-6ff6-4b37-a77f-34596b472e14",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9db59236-28a4-4fa5-a8db-96a517fa0f3b", "AQAAAAEAACcQAAAAENndAjKWzJeebZNRz3xzH3wQIa0vHfED8vlkjl11g4bE347JlemD7Pgy2vP0tpnOCw==", "818c126b-65ad-41cb-b2b9-cac030df6a85" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bacbe84a-94e8-418d-8e7d-7fba7cece7a0",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4db5303d-ed5b-4989-ab13-94ca3935bae5", "AQAAAAEAACcQAAAAEATXQspzEr/pS0sOjTd9gHHKnspVh0OG9W6XNmVT85N73B5qV0rKfErSOoRAYXLCIA==", "712a6fbe-a686-4168-b7c8-f85e43d9709d" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EventDate",
                table: "events");

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
    }
}
