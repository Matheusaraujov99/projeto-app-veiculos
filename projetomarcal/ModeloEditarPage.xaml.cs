using Microsoft.Maui.Controls;
using System;

namespace projetomarcal
{
    public partial class ModeloEditarPage : ContentPage
    {
        public Modelo Modelo { get; set; }
        public event EventHandler<Modelo> ModeloSalvo;

        public ModeloEditarPage(Modelo modelo)
        {
            InitializeComponent();
            Modelo = modelo ?? new Modelo();
            BindingContext = Modelo;
        }

        private async void SalvarModelo(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Modelo.Nome) || string.IsNullOrWhiteSpace(Modelo.Ano) || string.IsNullOrWhiteSpace(Modelo.Categoria))
            {
                await DisplayAlert("Erro", "Todos os campos devem ser preenchidos!", "OK");
                return;
            }

            ModeloSalvo?.Invoke(this, Modelo);
            await Navigation.PopAsync();
        }

        private async void Voltar(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}