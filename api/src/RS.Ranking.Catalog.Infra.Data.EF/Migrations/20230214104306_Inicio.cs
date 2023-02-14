using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RS.Ranking.Catalog.Infra.Data.EF.Migrations
{
    /// <inheritdoc />
    public partial class Inicio : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "ranking");

            migrationBuilder.CreateTable(
                name: "Categories",
                schema: "ranking",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "character varying(10000)", maxLength: 10000, nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.InsertData(
                schema: "ranking",
                table: "Categories",
                columns: new[] { "Id", "CreatedAt", "Description", "IsActive", "Name" },
                values: new object[] { new Guid("22d4aa78-89f5-449e-9a7c-df6d3f8e9e31"), new DateTime(2023, 2, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Descrição do eletrônico", true, "Eletrônicos" });

            migrationBuilder.CreateIndex(
                name: "IX_Categories_CreatedAt",
                schema: "ranking",
                table: "Categories",
                column: "CreatedAt");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Categories",
                schema: "ranking");
        }
    }
}
