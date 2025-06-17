using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class JsonStrings1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Coordinates_Structures_StructureId",
                table: "Coordinates");

            migrationBuilder.DropIndex(
                name: "IX_Coordinates_StructureId",
                table: "Coordinates");

            migrationBuilder.DropColumn(
                name: "StructureId",
                table: "Coordinates");

            migrationBuilder.AddColumn<string>(
                name: "CoordinatesJson",
                table: "Structures",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CoordinatesJson",
                table: "Structures");

            migrationBuilder.AddColumn<int>(
                name: "StructureId",
                table: "Coordinates",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Coordinates_StructureId",
                table: "Coordinates",
                column: "StructureId");

            migrationBuilder.AddForeignKey(
                name: "FK_Coordinates_Structures_StructureId",
                table: "Coordinates",
                column: "StructureId",
                principalTable: "Structures",
                principalColumn: "Id");
        }
    }
}
