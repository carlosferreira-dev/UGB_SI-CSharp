using RelacionamentoHeranca.Models;

namespace RelacionamentoHeranca.Models
{
    public class Produto
    {
        public int? ProdutoID { get; set; }
        public string Nome { get; set; }
        public decimal Valor { get; set; }
        public int Quantidade { get; set; }
    }
}


/* ==============================
 * Perecível
 * 
 * id = 1
 * nome = bolo P = 10
 * 
 * id = 2
 * nome = bolo M = 5
 * 
 * id = 3
 * nome = bolo G = 6
 * 
 * 
 * id = 1
 * nome = bolo P
 * valor = 20,00
 * quantidade = 10
 * DataValidade = 24/11/2023
 * Sabor = Cenoura
 * Peso = 0.500
 * ================================
 * Não Perecível
 * 
 * id = 1
 * nome = EnfeitesAdicionais
 * valor = 15,00
 * quantidade = 5
 * cor = rosa
 * tamanho = A4
 * material = papel
 ================================
 * 
 * produtos feitos, bolo cookie etc - perecível 
 * - DataValidade
 * - Sabor
 * - Peso
 * 
 * Embalagem, enfeites etc - não perecível
 * - Cor
 * - Tamanho
 * - Material
 */