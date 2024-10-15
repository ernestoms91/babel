using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Babel.Migrations
{
    /// <inheritdoc />
    public partial class SeedUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoleName = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Lastname = table.Column<string>(type: "text", nullable: false),
                    UserName = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Active = table.Column<bool>(type: "boolean", nullable: false),
                    Nid = table.Column<string>(type: "text", nullable: false),
                    Phone = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UsersRoles",
                columns: table => new
                {
                    UsuarioId = table.Column<int>(type: "integer", nullable: false),
                    RoleId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersRoles", x => new { x.UsuarioId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_UsersRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsersRoles_Users_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Active", "CreatedAt", "Description", "Email", "Lastname", "Name", "Nid", "Phone", "UpdatedAt", "UserName" },
                values: new object[,]
                {
                    { 1, true, new DateTime(2024, 10, 10, 3, 2, 15, 13, DateTimeKind.Utc).AddTicks(1076), "Admin user", "john.doe@example.com", "Doe", "John", "123456789", "123-456-7890", new DateTime(2024, 10, 10, 3, 2, 15, 13, DateTimeKind.Utc).AddTicks(1076), "johndoe" },
                    { 2, true, new DateTime(2024, 10, 10, 3, 2, 15, 13, DateTimeKind.Utc).AddTicks(1080), "Manager", "jane.smith@example.com", "Smith", "Jane", "987654321", "987-654-3210", new DateTime(2024, 10, 10, 3, 2, 15, 13, DateTimeKind.Utc).AddTicks(1081), "janesmith" },
                    { 3, true, new DateTime(2024, 10, 10, 3, 2, 15, 13, DateTimeKind.Utc).AddTicks(1083), "HR", "alice.johnson@example.com", "Johnson", "Alice", "123789456", "456-123-7890", new DateTime(2024, 10, 10, 3, 2, 15, 13, DateTimeKind.Utc).AddTicks(1083), "alicej" },
                    { 4, true, new DateTime(2024, 10, 10, 3, 2, 15, 13, DateTimeKind.Utc).AddTicks(1086), "IT Support", "bob.williams@example.com", "Williams", "Bob", "789456123", "321-654-9870", new DateTime(2024, 10, 10, 3, 2, 15, 13, DateTimeKind.Utc).AddTicks(1086), "bobwilliams" },
                    { 5, true, new DateTime(2024, 10, 10, 3, 2, 15, 13, DateTimeKind.Utc).AddTicks(1088), "Sales", "charlie.brown@example.com", "Brown", "Charlie", "456789123", "654-987-1230", new DateTime(2024, 10, 10, 3, 2, 15, 13, DateTimeKind.Utc).AddTicks(1089), "charliebrown" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_UsersRoles_RoleId",
                table: "UsersRoles",
                column: "RoleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UsersRoles");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
