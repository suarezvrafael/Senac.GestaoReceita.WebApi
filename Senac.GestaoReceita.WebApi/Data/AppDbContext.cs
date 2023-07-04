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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cidade>()
            .HasOne(c => c.Estado) // relacionamento um-para-um ou muitos-para-um
            .WithMany() // relacionamento muitos-para-muitos
            .HasForeignKey(c => c.EstadoId); // chave estrangeira

            modelBuilder.Entity<ReceitaIngrediente>()
            .HasOne(c => c.Receita) // relacionamento um-para-um ou muitos-para-um
            .WithMany() // relacionamento muitos-para-muitos
            .HasForeignKey(c => c.IdReceita); // chave estrangeira

            modelBuilder.Entity<ReceitaIngrediente>()
            .HasOne(c => c.Ingrediente) // relacionamento um-para-um ou muitos-para-um
            .WithMany() // relacionamento muitos-para-muitos
            .HasForeignKey(c => c.Idingrediente); // chave estrangeira

        }
    }
}
