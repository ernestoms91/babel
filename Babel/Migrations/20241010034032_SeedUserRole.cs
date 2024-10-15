using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Babel.Migrations
{
    /// <inheritdoc />
    public partial class SeedUserRole : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 10, 10, 3, 40, 32, 250, DateTimeKind.Utc).AddTicks(4142), new DateTime(2024, 10, 10, 3, 40, 32, 250, DateTimeKind.Utc).AddTicks(4143) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 10, 10, 3, 40, 32, 250, DateTimeKind.Utc).AddTicks(4146), new DateTime(2024, 10, 10, 3, 40, 32, 250, DateTimeKind.Utc).AddTicks(4147) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 10, 10, 3, 40, 32, 250, DateTimeKind.Utc).AddTicks(4150), new DateTime(2024, 10, 10, 3, 40, 32, 250, DateTimeKind.Utc).AddTicks(4150) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 10, 10, 3, 40, 32, 250, DateTimeKind.Utc).AddTicks(4152), new DateTime(2024, 10, 10, 3, 40, 32, 250, DateTimeKind.Utc).AddTicks(4152) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 10, 10, 3, 40, 32, 250, DateTimeKind.Utc).AddTicks(4155), new DateTime(2024, 10, 10, 3, 40, 32, 250, DateTimeKind.Utc).AddTicks(4155) });

            migrationBuilder.InsertData(
                table: "UsersRoles",
                columns: new[] { "RoleId", "UsuarioId" },
                values: new object[,]
                {
                    { 2, 1 },
                    { 1, 2 },
                    { 3, 3 },
                    { 3, 4 },
                    { 3, 5 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UsersRoles",
                keyColumns: new[] { "RoleId", "UsuarioId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "UsersRoles",
                keyColumns: new[] { "RoleId", "UsuarioId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "UsersRoles",
                keyColumns: new[] { "RoleId", "UsuarioId" },
                keyValues: new object[] { 3, 3 });

            migrationBuilder.DeleteData(
                table: "UsersRoles",
                keyColumns: new[] { "RoleId", "UsuarioId" },
                keyValues: new object[] { 3, 4 });

            migrationBuilder.DeleteData(
                table: "UsersRoles",
                keyColumns: new[] { "RoleId", "UsuarioId" },
                keyValues: new object[] { 3, 5 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 10, 10, 3, 19, 57, 151, DateTimeKind.Utc).AddTicks(7769), new DateTime(2024, 10, 10, 3, 19, 57, 151, DateTimeKind.Utc).AddTicks(7769) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 10, 10, 3, 19, 57, 151, DateTimeKind.Utc).AddTicks(7772), new DateTime(2024, 10, 10, 3, 19, 57, 151, DateTimeKind.Utc).AddTicks(7773) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 10, 10, 3, 19, 57, 151, DateTimeKind.Utc).AddTicks(7775), new DateTime(2024, 10, 10, 3, 19, 57, 151, DateTimeKind.Utc).AddTicks(7775) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 10, 10, 3, 19, 57, 151, DateTimeKind.Utc).AddTicks(7777), new DateTime(2024, 10, 10, 3, 19, 57, 151, DateTimeKind.Utc).AddTicks(7778) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 10, 10, 3, 19, 57, 151, DateTimeKind.Utc).AddTicks(7780), new DateTime(2024, 10, 10, 3, 19, 57, 151, DateTimeKind.Utc).AddTicks(7780) });
        }
    }
}
