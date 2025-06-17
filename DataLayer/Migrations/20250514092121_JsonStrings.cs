using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class JsonStrings : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Symbol",
                table: "Structures");

            migrationBuilder.AddColumn<string>(
                name: "ColorsJson",
                table: "Structures",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SymbolsJson",
                table: "Structures",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ColorsJson",
                table: "Structures");

            migrationBuilder.DropColumn(
                name: "SymbolsJson",
                table: "Structures");

            migrationBuilder.AddColumn<string>(
                name: "Symbol",
                table: "Structures",
                type: "nvarchar(1)",
                nullable: false,
                defaultValue: "");
        }
    }
}
