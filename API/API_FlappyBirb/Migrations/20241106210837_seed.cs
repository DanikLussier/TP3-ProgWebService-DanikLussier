using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace API_FlappyBirb.Migrations
{
    /// <inheritdoc />
    public partial class seed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "11111111-1111-1111-1111-111111111111", 0, "23490a9d-c2fc-4839-9f90-3f5d2ea4124c", "d@d.d", false, false, null, null, null, "AQAAAAIAAYagAAAAEBQrHFFORSjfOxGiWqz8aQ1MTl+yBkitXW7nLuTNr4M4+vC/2lGyvFdOWbJwUw1XiA==", null, false, "606398af-95dc-43e9-8184-dba49ec79226", false, "dan" },
                    { "22222222-2222-2222-2222-222222222222", 0, "74693afd-6696-4578-87f0-8cd78c0403bb", "a@a.a", false, false, null, null, null, null, null, false, "00412353-172a-4edd-8fb5-bc178db1e0f4", false, "ali" }
                });

            migrationBuilder.InsertData(
                table: "Score",
                columns: new[] { "Id", "Date", "Temps", "Value", "isVisible", "userId" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 11, 6, 16, 8, 37, 164, DateTimeKind.Local).AddTicks(5753), 4.6f, 5, true, "11111111-1111-1111-1111-111111111111" },
                    { 2, new DateTime(2024, 11, 6, 16, 8, 37, 164, DateTimeKind.Local).AddTicks(5827), 9.8f, 10, false, "11111111-1111-1111-1111-111111111111" },
                    { 3, new DateTime(2024, 11, 6, 16, 8, 37, 164, DateTimeKind.Local).AddTicks(5830), 20.3f, 12, true, "22222222-2222-2222-2222-222222222222" },
                    { 4, new DateTime(2024, 11, 6, 16, 8, 37, 164, DateTimeKind.Local).AddTicks(5832), 34.9f, 23, false, "22222222-2222-2222-2222-222222222222" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Score",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Score",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Score",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Score",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "22222222-2222-2222-2222-222222222222");
        }
    }
}
