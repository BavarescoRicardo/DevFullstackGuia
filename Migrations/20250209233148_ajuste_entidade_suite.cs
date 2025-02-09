using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DevFullstackGuia.Migrations
{
    /// <inheritdoc />
    public partial class ajuste_entidade_suite : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Disponivel",
                table: "Suite");

            migrationBuilder.AddColumn<double>(
                name: "Valor",
                table: "Suite",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Valor",
                table: "Suite");

            migrationBuilder.AddColumn<bool>(
                name: "Disponivel",
                table: "Suite",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }
    }
}
