using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Anotaçoes.Models;
using Anotaçoes.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Anotaçoes.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Lista : ContentPage
    {
        public Lista()
        {
            InitializeComponent();
            AtualizaLista();
        }
        public void AtualizaLista()
        {
            string titulo = "";
            if(BuscaTitulo.Text != null) titulo = BuscaTitulo.Text;
            ServicesDBNotas dbNotas = new ServicesDBNotas(App.dbPath);
            if (swFiltroFav.IsToggled)
            {
                ListaNotas.ItemsSource = dbNotas.Localizar(titulo,true);
            }
            else
            {

                ListaNotas.ItemsSource = dbNotas.Localizar(titulo);
            }
        }

        private void ListaNotas_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Notas nota = (Notas)ListaNotas.SelectedItem;
            //chamada da page cadastrar
            FlyoutPage p = (FlyoutPage)Application.Current.MainPage;
            p.Detail = new NavigationPage(new Cadastrar(nota));

        }

        private void swFiltroFav_Toggled(object sender, ToggledEventArgs e)
        {
                AtualizaLista();
        }

        private void Entry_TextChanged(object sender, TextChangedEventArgs e)
        {
            string titulo = BuscaTitulo.Text;
            ServicesDBNotas dbNotas = new ServicesDBNotas(App.dbPath);
            ListaNotas.ItemsSource = dbNotas.Localizar(titulo);
        }
    }
}