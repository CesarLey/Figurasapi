using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FigurasApi.Migrations
{
    /// <inheritdoc />
    public partial class AddLargoAnchoToFigura : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Ancho",
                table: "Figuras",
                type: "double precision",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Largo",
                table: "Figuras",
                type: "double precision",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ancho",
                table: "Figuras");

            migrationBuilder.DropColumn(
                name: "Largo",
                table: "Figuras");
        }
    }
}
