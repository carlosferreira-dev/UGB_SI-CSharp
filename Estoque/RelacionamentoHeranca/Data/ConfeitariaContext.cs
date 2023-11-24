using Microsoft.EntityFrameworkCore;
namespace RelacionamentoHeranca.Data
{
    public class ConfeitariaContext : DbContext
    {
        public ConfeitariaContext(DbContextOptions<ConfeitariaContext> options) : base(options) { }
        public DbSet<Produto> Produtos { get; set; }
    }
    
}
