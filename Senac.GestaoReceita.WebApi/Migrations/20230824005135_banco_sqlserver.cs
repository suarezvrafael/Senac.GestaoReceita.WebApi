using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Senac.GestaoReceita.WebApi.Migrations
{
    /// <inheritdoc />
    public partial class banco_sqlserver : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Paises",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", maxLength: 11, nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    descricaoPais = table.Column<string>(type: "nvarchar(140)", maxLength: 140, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paises", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Receitas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nomeReceita = table.Column<string>(type: "nvarchar(140)", maxLength: 140, nullable: false),
                    IdEmpresa = table.Column<int>(type: "int", nullable: false),
                    ValorTotalReceita = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Receitas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UnidadeMedida",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    descUnidMedIngrediente = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    sigla = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnidadeMedida", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Username = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Senha = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Acesso = table.Column<int>(type: "int", nullable: false),
                    ManterLogado = table.Column<int>(type: "int", nullable: false),
                    EmpresaId = table.Column<int>(type: "int", nullable: false),
                    Ativo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Estados",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", maxLength: 11, nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    descricaoEstado = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IdPais = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estados", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Estados_Paises_IdPais",
                        column: x => x.IdPais,
                        principalTable: "Paises",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cidades",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", maxLength: 11, nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    descricaoCidade = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IdEstado = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cidades", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cidades_Estados_IdEstado",
                        column: x => x.IdEstado,
                        principalTable: "Estados",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Empresas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CNPJ = table.Column<string>(type: "nvarchar(18)", maxLength: 18, nullable: false),
                    razaoSosial = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    rua = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    bairro = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    numeroEndereco = table.Column<int>(type: "int", nullable: false),
                    complemento = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    email = table.Column<string>(type: "nvarchar(90)", maxLength: 90, nullable: false),
                    telefone = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    nomeFantasia = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    idcidade = table.Column<int>(type: "int", nullable: false),
                    createEmpresa = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updateEmpresa = table.Column<DateTime>(type: "datetime2", nullable: false),
                    idUsername = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empresas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Empresas_Cidades_idcidade",
                        column: x => x.idcidade,
                        principalTable: "Cidades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ingredientes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeIngrediente = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    PrecoIngrediente = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    QuantidadeUnidade = table.Column<float>(type: "real", nullable: false),
                    EmpresaId = table.Column<int>(type: "int", nullable: false),
                    UnidadeMedidaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredientes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ingredientes_Empresas_EmpresaId",
                        column: x => x.EmpresaId,
                        principalTable: "Empresas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ingredientes_UnidadeMedida_UnidadeMedidaId",
                        column: x => x.UnidadeMedidaId,
                        principalTable: "UnidadeMedida",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReceitaIngredientes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdReceita = table.Column<int>(type: "int", nullable: false),
                    Idingrediente = table.Column<int>(type: "int", nullable: false),
                    quantidadeIngrediente = table.Column<int>(type: "int", nullable: false),
                    IdGastoVariado = table.Column<int>(type: "int", nullable: false),
                    qntGastoVariado = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ReceitaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReceitaIngredientes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReceitaIngredientes_Ingredientes_Idingrediente",
                        column: x => x.Idingrediente,
                        principalTable: "Ingredientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReceitaIngredientes_Receitas_IdReceita",
                        column: x => x.IdReceita,
                        principalTable: "Receitas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReceitaIngredientes_Receitas_ReceitaId",
                        column: x => x.ReceitaId,
                        principalTable: "Receitas",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cidades_IdEstado",
                table: "Cidades",
                column: "IdEstado");

            migrationBuilder.CreateIndex(
                name: "IX_Empresas_idcidade",
                table: "Empresas",
                column: "idcidade");

            migrationBuilder.CreateIndex(
                name: "IX_Estados_IdPais",
                table: "Estados",
                column: "IdPais");

            migrationBuilder.CreateIndex(
                name: "IX_Ingredientes_EmpresaId",
                table: "Ingredientes",
                column: "EmpresaId");

            migrationBuilder.CreateIndex(
                name: "IX_Ingredientes_UnidadeMedidaId",
                table: "Ingredientes",
                column: "UnidadeMedidaId");

            migrationBuilder.CreateIndex(
                name: "IX_ReceitaIngredientes_Idingrediente",
                table: "ReceitaIngredientes",
                column: "Idingrediente");

            migrationBuilder.CreateIndex(
                name: "IX_ReceitaIngredientes_IdReceita",
                table: "ReceitaIngredientes",
                column: "IdReceita");

            migrationBuilder.CreateIndex(
                name: "IX_ReceitaIngredientes_ReceitaId",
                table: "ReceitaIngredientes",
                column: "ReceitaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReceitaIngredientes");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Ingredientes");

            migrationBuilder.DropTable(
                name: "Receitas");

            migrationBuilder.DropTable(
                name: "Empresas");

            migrationBuilder.DropTable(
                name: "UnidadeMedida");

            migrationBuilder.DropTable(
                name: "Cidades");

            migrationBuilder.DropTable(
                name: "Estados");

            migrationBuilder.DropTable(
                name: "Paises");
        }
    }
}
