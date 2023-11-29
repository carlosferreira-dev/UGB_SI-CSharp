using RelacionamentoHeranca.Models;

namespace RelacionamentoHeranca.Models
{
    public class Produto
    {
        public int? ProdutoID { get; set; }
        public string Nome { get; set; }
        public double Valor { get; set; }
        public int Quantidade { get; set; }
    }
}