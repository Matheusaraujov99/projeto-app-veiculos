using System.ComponentModel;

namespace projetomarcal
{
    public class VeiculoModel : INotifyPropertyChanged
    {
        public string Nome { get; set; }
        public string Tipo { get; set; } 
        public double Preco { get; set; }
        public int Quilometragem { get; set; }
        public bool SemiNovo { get; set; }

        private string carrinhoTexto = "Adicionar ao Carrinho";
        public string CarrinhoTexto
        {
            get => carrinhoTexto;
            set
            {
                if (carrinhoTexto != value)
                {
                    carrinhoTexto = value;
                    OnPropertyChanged(nameof(CarrinhoTexto));
                }
            }
        }

        private string corBotao = "#D94814";
        public string CorBotao
        {
            get => corBotao;
            set
            {
                if (corBotao != value)
                {
                    corBotao = value;
                    OnPropertyChanged(nameof(CorBotao));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}