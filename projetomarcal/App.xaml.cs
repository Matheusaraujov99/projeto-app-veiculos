using Microsoft.Maui.Controls;

namespace projetomarcal
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
        }
    }
}