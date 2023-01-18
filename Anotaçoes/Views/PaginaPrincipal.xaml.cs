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
    public partial class PaginaPrincipal : FlyoutPage
    {
        public PaginaPrincipal()
        {
            InitializeComponent();
            btHome_Clicked(new Object(), new EventArgs());
        }

        private void btHome_Clicked(object sender, EventArgs e)
        {
            Detail = new NavigationPage(new Home());
            IsPresented = false;
        }

        private void btCadastrar_Clicked(object sender, EventArgs e)
        {
            Detail = new NavigationPage(new Cadastrar());
            IsPresented = false;
        }

        private void btLista_Clicked(object sender, EventArgs e)
        {
            Detail = new NavigationPage(new Lista());
            IsPresented = false;
        }

        private void btSobre_Clicked(object sender, EventArgs e)
        {
            Detail = new NavigationPage(new Sobre());
            IsPresented = false;
        }
    }
}