using System.Collections.ObjectModel;
using Microsoft.Maui.Controls;

namespace projetomarcal
{
    public partial class ModeloPage : ContentPage
    {
        public ObservableCollection<Modelo> Modelos { get; set; } = new();
        public ObservableCollection<Modelo> ModelosFiltrados { get; set; } = new();

        public ModeloPage()
        {
            InitializeComponent();

            
            Modelos.Add(new Modelo { Id = 1, Nome = "Toyota Corolla", Ano = "2022", Categoria = "Sedan" });
            Modelos.Add(new Modelo { Id = 2, Nome = "Honda Civic", Ano = "2021", Categoria = "Sedan" });

            ModelosFiltrados = new ObservableCollection<Modelo>(Modelos);
            BindingContext = this;
        }

        private async void AdicionarModelo(object sender, EventArgs e)
        {
            var novaPagina = new ModeloEditarPage(null);
            novaPagina.ModeloSalvo += (s, novoModelo) =>
            {
                if (novoModelo != null)
                {
                    Modelos.Add(novoModelo);
                    ModelosFiltrados.Add(novoModelo);
                }
            };
            await Navigation.PushAsync(novaPagina);
        }

        private async void EditarModelo(object sender, EventArgs e)
        {
            var modelo = (Modelo)((Button)sender).CommandParameter;
            var novaPagina = new ModeloEditarPage(modelo);

            novaPagina.ModeloSalvo += (s, modeloEditado) =>
            {
                if (modeloEditado != null)
                {
                    
                    var index = Modelos.IndexOf(modelo);
                    if (index >= 0)
                    {
                        Modelos[index] = modeloEditado;
                        ModelosFiltrados[index] = modeloEditado;
                    }
                }
            };

            await Navigation.PushAsync(novaPagina);
        }

        private void ExcluirModelo(object sender, EventArgs e)
        {
            var modelo = (Modelo)((Button)sender).CommandParameter;
            Modelos.Remove(modelo);
            ModelosFiltrados.Remove(modelo);
        }

        private void OnSearchTextChanged(object sender, TextChangedEventArgs e)
        {
            string searchText = e.NewTextValue?.ToLower() ?? string.Empty;
            ModelosFiltrados.Clear();
            foreach (var modelo in Modelos)
            {
                if (modelo.Nome.ToLower().Contains(searchText) || modelo.Categoria.ToLower().Contains(searchText))
                {
                    ModelosFiltrados.Add(modelo);
                }
            }
        }
    }
}