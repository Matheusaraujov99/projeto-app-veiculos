using System.Collections.ObjectModel;
using Microsoft.Maui.Controls;
using projetomarcal;  

namespace projetomarcal
{
    public partial class Veiculo : ContentPage
    {
        public ObservableCollection<VeiculoModel> Veiculos { get; set; }
        public ObservableCollection<VeiculoModel> Carrinho { get; set; } = new ObservableCollection<VeiculoModel>();

        public Veiculo()
        {
            InitializeComponent();

            Veiculos = new ObservableCollection<VeiculoModel>
            {
                new VeiculoModel { Nome = "Toyota Corolla", Preco = 120000, Quilometragem = 25000, SemiNovo = true },
                new VeiculoModel { Nome = "Honda Civic", Preco = 130000, Quilometragem = 18000, SemiNovo = true },
                new VeiculoModel { Nome = "Jeep Renegade", Preco = 140000, Quilometragem = 0, SemiNovo = false },
                new VeiculoModel { Nome = "Fiat Pulse", Preco = 110000, Quilometragem = 5000, SemiNovo = true },
                new VeiculoModel { Nome = "Chevrolet Onix", Preco = 90000, Quilometragem = 12000, SemiNovo = true },
                new VeiculoModel { Nome = "Volkswagen Polo", Preco = 95000, Quilometragem = 15000, SemiNovo = true },
                new VeiculoModel { Nome = "Ford EcoSport", Preco = 100000, Quilometragem = 22000, SemiNovo = true }
            };

            foreach (var veiculo in Veiculos)
            {
                AtualizarEstadoDoBotao(veiculo);
            }

            BindingContext = this;
        }

        private void ToggleCarrinho(object sender, EventArgs e)
        {
            var botao = (Button)sender;
            var veiculo = (VeiculoModel)botao.CommandParameter;

            if (Carrinho.Contains(veiculo))
            {
                Carrinho.Remove(veiculo);
            }
            else
            {
                Carrinho.Add(veiculo);
            }

            AtualizarEstadoDoBotao(veiculo);
        }

        private void AtualizarEstadoDoBotao(VeiculoModel veiculo)
        {
            veiculo.CarrinhoTexto = Carrinho.Contains(veiculo) ? "Remover do Carrinho" : "Adicionar ao Carrinho";
            veiculo.CorBotao = Carrinho.Contains(veiculo) ? "Red" : "#D94814";
        }
    }
}