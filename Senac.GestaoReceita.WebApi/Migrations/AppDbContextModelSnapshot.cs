﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Senac.GestaoReceita.WebApi.Data;

#nullable disable

namespace Senac.GestaoReceita.WebApi.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Senac.GestaoReceita.WebApi.Models.Cidade", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(11)
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("IdEstado")
                        .HasColumnType("int");

                    b.Property<string>("descricaoCidade")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("IdEstado");

                    b.ToTable("Cidades");
                });

            modelBuilder.Entity("Senac.GestaoReceita.WebApi.Models.Empresa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CNPJ")
                        .IsRequired()
                        .HasMaxLength(18)
                        .HasColumnType("nvarchar(18)");

                    b.Property<string>("bairro")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("complemento")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTime>("createEmpresa")
                        .HasColumnType("datetime2");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasMaxLength(90)
                        .HasColumnType("nvarchar(90)");

                    b.Property<int>("idUsername")
                        .HasColumnType("int");

                    b.Property<int>("idcidade")
                        .HasColumnType("int");

                    b.Property<string>("nomeFantasia")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<int>("numeroEndereco")
                        .HasColumnType("int");

                    b.Property<string>("razaoSosial")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("rua")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("telefone")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<DateTime>("updateEmpresa")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("idcidade");

                    b.ToTable("Empresas");
                });

            modelBuilder.Entity("Senac.GestaoReceita.WebApi.Models.Estado", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(11)
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("IdPais")
                        .HasColumnType("int");

                    b.Property<string>("descricaoEstado")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("IdPais");

                    b.ToTable("Estados");
                });

            modelBuilder.Entity("Senac.GestaoReceita.WebApi.Models.Ingrediente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("EmpresaId")
                        .HasColumnType("int");

                    b.Property<string>("NomeIngrediente")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<decimal>("PrecoIngrediente")
                        .HasColumnType("decimal(18,2)");

                    b.Property<float>("QuantidadeUnidade")
                        .HasColumnType("real");

                    b.Property<int>("UnidadeMedidaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EmpresaId");

                    b.HasIndex("UnidadeMedidaId");

                    b.ToTable("Ingredientes");
                });

            modelBuilder.Entity("Senac.GestaoReceita.WebApi.Models.Pais", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(11)
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("descricaoPais")
                        .IsRequired()
                        .HasMaxLength(140)
                        .HasColumnType("nvarchar(140)");

                    b.HasKey("Id");

                    b.ToTable("Paises");
                });

            modelBuilder.Entity("Senac.GestaoReceita.WebApi.Models.Receita", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("IdEmpresa")
                        .HasColumnType("int");

                    b.Property<string>("ModoPreparo")
                        .IsRequired()
                        .HasMaxLength(600)
                        .HasColumnType("nvarchar(600)");

                    b.Property<decimal>("ValorTotalReceita")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("nomeReceita")
                        .IsRequired()
                        .HasMaxLength(140)
                        .HasColumnType("nvarchar(140)");

                    b.HasKey("Id");

                    b.ToTable("Receitas");
                });

            modelBuilder.Entity("Senac.GestaoReceita.WebApi.Models.ReceitaIngrediente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("IdGastoVariado")
                        .HasColumnType("int");

                    b.Property<int>("IdReceita")
                        .HasColumnType("int");

                    b.Property<int>("Idingrediente")
                        .HasColumnType("int");

                    b.Property<int?>("ReceitaId")
                        .HasColumnType("int");

                    b.Property<decimal>("qntGastoVariado")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("quantidadeIngrediente")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdReceita");

                    b.HasIndex("Idingrediente");

                    b.HasIndex("ReceitaId");

                    b.ToTable("ReceitaIngredientes");
                });

            modelBuilder.Entity("Senac.GestaoReceita.WebApi.Models.UnidadeMedida", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("descUnidMedIngrediente")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("sigla")
                        .IsRequired()
                        .HasMaxLength(5)
                        .HasColumnType("nvarchar(5)");

                    b.HasKey("Id");

                    b.ToTable("UnidadeMedida");
                });

            modelBuilder.Entity("Senac.GestaoReceita.WebApi.Models.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Acesso")
                        .HasColumnType("int");

                    b.Property<int>("Ativo")
                        .HasColumnType("int");

                    b.Property<int>("EmpresaId")
                        .HasColumnType("int");

                    b.Property<int>("ManterLogado")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("Id");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("Senac.GestaoReceita.WebApi.Models.Cidade", b =>
                {
                    b.HasOne("Senac.GestaoReceita.WebApi.Models.Estado", "Estado")
                        .WithMany()
                        .HasForeignKey("IdEstado")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Estado");
                });

            modelBuilder.Entity("Senac.GestaoReceita.WebApi.Models.Empresa", b =>
                {
                    b.HasOne("Senac.GestaoReceita.WebApi.Models.Cidade", "cidade")
                        .WithMany()
                        .HasForeignKey("idcidade")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("cidade");
                });

            modelBuilder.Entity("Senac.GestaoReceita.WebApi.Models.Estado", b =>
                {
                    b.HasOne("Senac.GestaoReceita.WebApi.Models.Pais", "Pais")
                        .WithMany()
                        .HasForeignKey("IdPais")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pais");
                });

            modelBuilder.Entity("Senac.GestaoReceita.WebApi.Models.Ingrediente", b =>
                {
                    b.HasOne("Senac.GestaoReceita.WebApi.Models.Empresa", "Empresa")
                        .WithMany()
                        .HasForeignKey("EmpresaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Senac.GestaoReceita.WebApi.Models.UnidadeMedida", "UnidadeMedida")
                        .WithMany()
                        .HasForeignKey("UnidadeMedidaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Empresa");

                    b.Navigation("UnidadeMedida");
                });

            modelBuilder.Entity("Senac.GestaoReceita.WebApi.Models.ReceitaIngrediente", b =>
                {
                    b.HasOne("Senac.GestaoReceita.WebApi.Models.Receita", "Receita")
                        .WithMany()
                        .HasForeignKey("IdReceita")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Senac.GestaoReceita.WebApi.Models.Ingrediente", "Ingrediente")
                        .WithMany()
                        .HasForeignKey("Idingrediente")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Senac.GestaoReceita.WebApi.Models.Receita", null)
                        .WithMany("ReceitaIngrediente")
                        .HasForeignKey("ReceitaId");

                    b.Navigation("Ingrediente");

                    b.Navigation("Receita");
                });

            modelBuilder.Entity("Senac.GestaoReceita.WebApi.Models.Receita", b =>
                {
                    b.Navigation("ReceitaIngrediente");
                });
#pragma warning restore 612, 618
        }
    }
}
