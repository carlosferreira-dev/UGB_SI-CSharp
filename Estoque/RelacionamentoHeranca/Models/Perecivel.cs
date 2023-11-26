namespace RelacionamentoHeranca.Models
{
    public class Perecivel : Produto
    {
        public DateTime DataValidade { get; set; }
        public string? Sabor { get; set; }
        public decimal Peso { get; set; }
    }
}
