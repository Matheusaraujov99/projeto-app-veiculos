using System;
using System.Collections.ObjectModel;
using Microsoft.Maui.Controls;

namespace projetomarcal
{
    public partial class Marca : ContentPage
    {
        private ObservableCollection<MarcaModel> marcas;

        public Marca()
        {
            InitializeComponent();
            marcas = new ObservableCollection<MarcaModel>();
            ListaMarcas.ItemsSource = marcas;
        }

        private async void OnAdicionarClicked(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(EntryMarca.Text) ||
                string.IsNullOrWhiteSpace(EntryModelo.Text) ||
                string.IsNullOrWhiteSpace(EntryAno.Text) ||
                PickerSituacao.SelectedItem == null ||
                string.IsNullOrWhiteSpace(EntryPreco.Text))
            {
                await DisplayAlert("Erro", "Preencha todos os campos!", "OK");
                return;
            }

            if (!int.TryParse(EntryAno.Text, out int ano))
            {
                await DisplayAlert("Erro", "Ano inválido! Digite um número válido.", "OK");
                return;
            }

            if (!decimal.TryParse(EntryPreco.Text, out decimal preco))
            {
                await DisplayAlert("Erro", "Preço inválido! Digite um valor numérico.", "OK");
                return;
            }

            var novaMarca = new MarcaModel
            {
                Marca = EntryMarca.Text,
                Modelo = EntryModelo.Text,
                Ano = ano,
                Situacao = PickerSituacao.SelectedItem.ToString(),
                Preco = preco
            };

            marcas.Add(novaMarca);

           
            EntryMarca.Text = "";
            EntryModelo.Text = "";
            EntryAno.Text = "";
            PickerSituacao.SelectedIndex = -1;
            EntryPreco.Text = "";
        }

        private void OnRemoverClicked(object sender, EventArgs e)
        {
            if (marcas.Count == 0) return; 

            var button = sender as Button;
            var item = button?.BindingContext as MarcaModel;

            if (item != null && marcas.Contains(item))
            {
                marcas.Remove(item);
            }
        }
    }

    public class MarcaModel
    {
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public int Ano { get; set; } 
        public string Situacao { get; set; }
        public decimal Preco { get; set; }
    }
}