﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
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
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Senac.GestaoReceita.WebApi.Models.Cidade", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("EstadoId")
                        .HasColumnType("int");

                    b.Property<string>("descricaoCidade")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)");

                    b.HasKey("Id");

                    b.HasIndex("EstadoId");

                    b.ToTable("Cidades");
                });

            modelBuilder.Entity("Senac.GestaoReceita.WebApi.Models.Estado", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Sigla")
                        .IsRequired()
                        .HasMaxLength(2)
                        .HasColumnType("varchar(2)");

                    b.HasKey("Id");

                    b.ToTable("Estados");
                });

            modelBuilder.Entity("Senac.GestaoReceita.WebApi.Models.Receita", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("IdEmpresa")
                        .HasColumnType("int");

                    b.Property<decimal>("ValorTotalReceita")
                        .HasColumnType("decimal(65,30)");

                    b.Property<string>("nomeReceita")
                        .IsRequired()
                        .HasMaxLength(140)
                        .HasColumnType("varchar(140)");

                    b.HasKey("Id");

                    b.ToTable("Receita");
                });

            modelBuilder.Entity("Senac.GestaoReceita.WebApi.Models.ReceitaIngrediente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("IdGastoVariado")
                        .HasColumnType("int");

                    b.Property<int>("IdIngrediente")
                        .HasColumnType("int");

                    b.Property<int>("IdReceita")
                        .HasColumnType("int");

                    b.Property<decimal>("qntGastoVariado")
                        .HasColumnType("decimal(65,30)");

                    b.Property<int>("quantidadeIngrediente")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdReceita");

                    b.ToTable("ReceitaIngredientes");
                });

            modelBuilder.Entity("Senac.GestaoReceita.WebApi.Models.Cidade", b =>
                {
                    b.HasOne("Senac.GestaoReceita.WebApi.Models.Estado", "Estado")
                        .WithMany()
                        .HasForeignKey("EstadoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Estado");
                });

            modelBuilder.Entity("Senac.GestaoReceita.WebApi.Models.ReceitaIngrediente", b =>
                {
                    b.HasOne("Senac.GestaoReceita.WebApi.Models.Receita", "Receita")
                        .WithMany()
                        .HasForeignKey("IdReceita")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Receita");
                });
#pragma warning restore 612, 618
        }
    }
}
