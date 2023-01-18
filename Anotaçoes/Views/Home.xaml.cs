using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Anotaçoes.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Home : ContentPage
    {
        public Home()
        {
            InitializeComponent();
        }

        private async void btNovo_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Cadastrar());
        }

        private async void btBusca_Clicked(object sender, EventArgs e)
        {
        
        }

        private async void btListar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Lista());

        }

        private async void btSobre_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Sobre());
        }
    }
}