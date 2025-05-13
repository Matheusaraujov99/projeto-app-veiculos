using System.Collections.ObjectModel;
using System.Windows.Input;
using Microsoft.Maui.Controls;

namespace projetomarcal
{
    public class VeiculoViewModel
    {
        public ObservableCollection<VeiculoModel> Veiculos { get; set; }
        public ObservableCollection<VeiculoModel> Carrinho { get; set; }
        public ICommand AdicionarRemoverCarrinhoCommand { get; }

        public VeiculoViewModel()
        {
            Veiculos = new ObservableCollection<VeiculoModel>
            {
                new VeiculoModel { Nome = "Carro A", Tipo = "Sedan", Preco = 50000, Quilometragem = 20000 },
                new VeiculoModel { Nome = "Carro B", Tipo = "SUV", Preco = 80000, Quilometragem = 10000 }
            };

            Carrinho = new ObservableCollection<VeiculoModel>();

            AdicionarRemoverCarrinhoCommand = new Command<VeiculoModel>(AdicionarRemoverCarrinho);
        }

        private void AdicionarRemoverCarrinho(VeiculoModel veiculo)
        {
            if (veiculo == null)
                return;

            if (Carrinho.Contains(veiculo))
            {
                Carrinho.Remove(veiculo);
                veiculo.CarrinhoTexto = "Adicionar ao Carrinho";
                veiculo.CorBotao = "#D94814";
            }
            else
            {
                Carrinho.Add(veiculo);
                veiculo.CarrinhoTexto = "Remover do Carrinho";
                veiculo.CorBotao = "#0B6623";
        }
    }
    }
}
