using System.Collections.ObjectModel;
using Microsoft.Maui.Controls;

namespace projetomarcal
{
    public partial class Veiculo : ContentPage
    {
        public ObservableCollection<VeiculoModel> Veiculos { get; set; }

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

            BindingContext = this;
        }
    }
}