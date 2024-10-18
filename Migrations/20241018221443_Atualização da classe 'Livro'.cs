using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EF.Exemplo6.Migrations
{
    /// <inheritdoc />
    public partial class AtualizaçãodaclasseLivro : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Estoque",
                table: "Livro",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Estoque",
                table: "Livro");
        }
    }
}
