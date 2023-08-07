using Microsoft.EntityFrameworkCore;
using Senac.GestaoReceita.WebApi.Models;

namespace Senac.GestaoReceita.WebApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opcoes) : base(opcoes)
        {

        }

        public DbSet<Cidade> Cidades { get; set; }
        public DbSet<Estado> Estados { get; set; }
        public DbSet<Receita> Receitas { get; set; }
        public DbSet<ReceitaIngrediente> ReceitaIngredientes { get; set; }
        public DbSet<Ingrediente> Ingredientes { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Pais> Paises { get; set; }



        public DbSet<Empresa> Empresas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cidade>()
            .HasOne(c => c.Estado) // relacionamento um-para-um ou muitos-para-um
            .WithMany() // relacionamento muitos-para-muitos
            .HasForeignKey(c => c.IdEstado); // chave estrangeira

            modelBuilder.Entity<ReceitaIngrediente>()
            .HasOne(c => c.Receita) // relacionamento um-para-um ou muitos-para-um
            .WithMany() // relacionamento muitos-para-muitos
            .HasForeignKey(c => c.IdReceita); // chave estrangeira

            modelBuilder.Entity<ReceitaIngrediente>()
            .HasOne(c => c.Ingrediente) // relacionamento um-para-um ou muitos-para-um
            .WithMany() // relacionamento muitos-para-muitos
            .HasForeignKey(c => c.Idingrediente); // chave estrangeira


            modelBuilder.Entity<Empresa>()
            .HasOne(c => c.cidade) // relacionamento um-para-um ou muitos-para-um
            .WithMany() // relacionamento muitos-para-muitos
            .HasForeignKey(c => c.idcidade); // chave estrangeira

            modelBuilder.Entity<Estado>()
            .HasOne(c => c.Pais) 
            .WithMany() 
            .HasForeignKey(c => c. IdPais); 


            modelBuilder.Entity<Ingrediente>()
            .HasOne(i => i.Empresa)
            .WithMany()
            .HasForeignKey(i => i.EmpresaId);

            modelBuilder.Entity<Ingrediente>()
           .HasOne(u => u.UnidadeMedida)
           .WithMany()
           .HasForeignKey(u => u.UnidadeMedidaId);
        }
    }
}
