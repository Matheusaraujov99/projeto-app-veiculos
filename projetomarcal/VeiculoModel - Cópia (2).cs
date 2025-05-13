namespace projetomarcal
{
    public class VeiculoModel
    {
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public int Quilometragem { get; set; }
        public bool SemiNovo { get; set; }

        public string Tipo => SemiNovo ? "🚘 Seminovo" : "🆕 Novo";
    }
}