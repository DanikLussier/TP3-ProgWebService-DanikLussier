using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_FlappyBirb.Migrations
{
    /// <inheritdoc />
    public partial class seed3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fd70e99e-df45-484a-8089-ff8d25c5e3c7", "D@D.D", "DAN", "AQAAAAIAAYagAAAAEMT2FFxpXAWEd3qSKKvUiON0CE55i91+T0Rgn2cynxGEf40dHPea8HehK7j76893Og==", "187a9a09-8267-41d4-9736-d3c3a78a31ee" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "22222222-2222-2222-2222-222222222222",
                columns: new[] { "ConcurrencyStamp", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "378abc07-d686-4ee9-a1e9-f6eadac444bd", "A@A.A", "ALI", "AQAAAAIAAYagAAAAEH38P8Y0TjYzCB895eoJrL7CUZrQWJWGnjFHUy9qOHcUOjHZLCI5XbBX5HCA53gn0w==", "664df407-36dc-4027-8226-d5c9f63e3b85" });

            migrationBuilder.UpdateData(
                table: "Score",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2024, 11, 7, 8, 54, 25, 173, DateTimeKind.Local).AddTicks(1326));

            migrationBuilder.UpdateData(
                table: "Score",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2024, 11, 7, 8, 54, 25, 173, DateTimeKind.Local).AddTicks(1410));

            migrationBuilder.UpdateData(
                table: "Score",
                keyColumn: "Id",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2024, 11, 7, 8, 54, 25, 173, DateTimeKind.Local).AddTicks(1413));

            migrationBuilder.UpdateData(
                table: "Score",
                keyColumn: "Id",
                keyValue: 4,
                column: "Date",
                value: new DateTime(2024, 11, 7, 8, 54, 25, 173, DateTimeKind.Local).AddTicks(1414));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4a7ecc4f-dfe4-467d-80b7-1f885aab3257", null, null, "AQAAAAIAAYagAAAAECAjv8Xxb5t9e799HFk3sZS094pPUv+uNpWkvDATuLByCdqmNfXLuyDjEKucPg/fJg==", "402a40ed-3b20-476f-b2c3-ea7e21ea4545" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "22222222-2222-2222-2222-222222222222",
                columns: new[] { "ConcurrencyStamp", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9860d037-8bf6-46ef-af64-5ac1ffe0d6b0", null, null, "AQAAAAIAAYagAAAAEEFmbzuuQNyv2ehcgqyuEfP8nCABz5//hjeagbE3krCkWI3fFlanqHLbUvEblqP0nw==", "70eb651a-e03f-4b7c-817b-a676fef64469" });

            migrationBuilder.UpdateData(
                table: "Score",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2024, 11, 6, 16, 13, 2, 655, DateTimeKind.Local).AddTicks(969));

            migrationBuilder.UpdateData(
                table: "Score",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2024, 11, 6, 16, 13, 2, 655, DateTimeKind.Local).AddTicks(1077));

            migrationBuilder.UpdateData(
                table: "Score",
                keyColumn: "Id",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2024, 11, 6, 16, 13, 2, 655, DateTimeKind.Local).AddTicks(1083));

            migrationBuilder.UpdateData(
                table: "Score",
                keyColumn: "Id",
                keyValue: 4,
                column: "Date",
                value: new DateTime(2024, 11, 6, 16, 13, 2, 655, DateTimeKind.Local).AddTicks(1087));
        }
    }
}
