using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Senac.GestaoReceita.WebApi.Migrations
{
    /// <inheritdoc />
    public partial class receita_modo_preparo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ModoPreparo",
                table: "Receitas",
                type: "nvarchar(600)",
                maxLength: 600,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ModoPreparo",
                table: "Receitas");
        }
    }
}
