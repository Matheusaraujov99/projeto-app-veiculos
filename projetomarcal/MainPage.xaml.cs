using System;
using Microsoft.Maui.ApplicationModel.DataTransfer;
using Microsoft.Maui.Controls;

namespace projetomarcal
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void BTNMarca_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Marca());
        }

        private async void BTNVeiculo_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Veiculo());
        }

        private async void BTNModelo_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ModeloPage());
        }

        private async void BTNSobre_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Sobre());
        }
    }
}