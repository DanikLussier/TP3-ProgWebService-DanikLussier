using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_FlappyBirb.Migrations
{
    /// <inheritdoc />
    public partial class seed2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4a7ecc4f-dfe4-467d-80b7-1f885aab3257", "AQAAAAIAAYagAAAAECAjv8Xxb5t9e799HFk3sZS094pPUv+uNpWkvDATuLByCdqmNfXLuyDjEKucPg/fJg==", "402a40ed-3b20-476f-b2c3-ea7e21ea4545" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "22222222-2222-2222-2222-222222222222",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9860d037-8bf6-46ef-af64-5ac1ffe0d6b0", "AQAAAAIAAYagAAAAEEFmbzuuQNyv2ehcgqyuEfP8nCABz5//hjeagbE3krCkWI3fFlanqHLbUvEblqP0nw==", "70eb651a-e03f-4b7c-817b-a676fef64469" });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "23490a9d-c2fc-4839-9f90-3f5d2ea4124c", "AQAAAAIAAYagAAAAEBQrHFFORSjfOxGiWqz8aQ1MTl+yBkitXW7nLuTNr4M4+vC/2lGyvFdOWbJwUw1XiA==", "606398af-95dc-43e9-8184-dba49ec79226" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "22222222-2222-2222-2222-222222222222",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "74693afd-6696-4578-87f0-8cd78c0403bb", null, "00412353-172a-4edd-8fb5-bc178db1e0f4" });

            migrationBuilder.UpdateData(
                table: "Score",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2024, 11, 6, 16, 8, 37, 164, DateTimeKind.Local).AddTicks(5753));

            migrationBuilder.UpdateData(
                table: "Score",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2024, 11, 6, 16, 8, 37, 164, DateTimeKind.Local).AddTicks(5827));

            migrationBuilder.UpdateData(
                table: "Score",
                keyColumn: "Id",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2024, 11, 6, 16, 8, 37, 164, DateTimeKind.Local).AddTicks(5830));

            migrationBuilder.UpdateData(
                table: "Score",
                keyColumn: "Id",
                keyValue: 4,
                column: "Date",
                value: new DateTime(2024, 11, 6, 16, 8, 37, 164, DateTimeKind.Local).AddTicks(5832));
        }
    }
}
