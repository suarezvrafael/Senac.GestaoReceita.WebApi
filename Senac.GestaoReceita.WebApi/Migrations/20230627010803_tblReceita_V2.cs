using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Senac.GestaoReceita.WebApi.Migrations
{
    /// <inheritdoc />
    public partial class tblReceita_V2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_ReceitaIngredientes_IdReceita",
                table: "ReceitaIngredientes",
                column: "IdReceita");

            migrationBuilder.AddForeignKey(
                name: "FK_ReceitaIngredientes_Receita_IdReceita",
                table: "ReceitaIngredientes",
                column: "IdReceita",
                principalTable: "Receita",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReceitaIngredientes_Receita_IdReceita",
                table: "ReceitaIngredientes");

            migrationBuilder.DropIndex(
                name: "IX_ReceitaIngredientes_IdReceita",
                table: "ReceitaIngredientes");
        }
    }
}
