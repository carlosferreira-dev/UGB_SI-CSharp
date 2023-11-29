using Microsoft.EntityFrameworkCore;
using RelacionamentoHeranca.Models;

namespace RelacionamentoHeranca.Data
{
    public class EstoqueContext : DbContext
    {
        public EstoqueContext(DbContextOptions<EstoqueContext> options) : base(options) { }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<RelacionamentoHeranca.Models.Perecivel> Pereciveis { get; set; } = default!;
        public DbSet<RelacionamentoHeranca.Models.NaoPerecivel> NaoPereciveis { get; set; } = default!;
    }
    
}
