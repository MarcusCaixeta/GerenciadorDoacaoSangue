using GerenciadorDoacaoSangue.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace GerenciadorDoacaoSangue.Infrastructure.Persistence
{
    public class GerenciadorDoacaoSangueDbContext : DbContext
    {
        public GerenciadorDoacaoSangueDbContext(DbContextOptions<GerenciadorDoacaoSangueDbContext> options) : base(options) { }

        public DbSet<Doacao> Doacao { get; set; }
        public DbSet<Doador> Doador { get;  set; }
        public DbSet<EstoqueSangue> EstoqueSangue { get;  set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());           
        }
    }
}
