using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Senac.GestaoReceita.WebApi.Migrations
{
    /// <inheritdoc />
    public partial class tblReceitaIngrediente : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ReceitaIngredientes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IdIngrediente = table.Column<int>(type: "int", nullable: false),
                    IdReceita = table.Column<int>(type: "int", nullable: false),
                    quantidadeIngrediente = table.Column<int>(type: "int", nullable: false),
                    IdGastoVariado = table.Column<int>(type: "int", nullable: false),
                    qntGastoVariado = table.Column<decimal>(type: "decimal(65,30)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReceitaIngredientes", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReceitaIngredientes");
        }
    }
}
