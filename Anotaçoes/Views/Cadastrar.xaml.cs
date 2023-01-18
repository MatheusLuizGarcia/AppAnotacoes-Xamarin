using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Anotaçoes.Models;
using Anotaçoes.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Anotaçoes.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Cadastrar : ContentPage
    {
        public Cadastrar()
        {
            InitializeComponent();
        }

        public Cadastrar(Notas nota)
        {
            InitializeComponent();
            lbCodigo.Text = nota.Id.ToString();
            btSalvar.Text = "Alterar";
            btExcluir.IsVisible = true;
            etTitulo.Text = nota.Titulo;
            etDados.Text = nota.Dados;
            swFavorito.IsToggled = nota.Favorito;
        }

        private void btSalvar_Clicked(object sender, EventArgs e)
        {
            try { 
                Notas nota = new Notas();
                nota.Titulo = etTitulo.Text;
                nota.Dados = etDados.Text;
                nota.Favorito = swFavorito.IsToggled;
                ServicesDBNotas dbNotas = new ServicesDBNotas(App.dbPath);
                if(btSalvar.Text == "Registrar")
                {
                    dbNotas.Inserir(nota);
                    DisplayAlert("Resultado da operação", dbNotas.StatusMessage, "OK");
                }
                else
                {
                    // alterar
                    nota.Id = Convert.ToInt32(lbCodigo.Text);
                    dbNotas.Atualizar(nota);
                    DisplayAlert("Rsultado da operação", dbNotas.StatusMessage, "OK");
                }
                FlyoutPage p = (FlyoutPage)Application.Current.MainPage;
                p.Detail = new NavigationPage(new Home());
            }
            catch (Exception ex)
            {
                DisplayAlert("Erro", ex.Message, "OK");
            }
        }

        private void btCancelar_Clicked(object sender, EventArgs e)
        {
            FlyoutPage p = (FlyoutPage)Application.Current.MainPage;
            p.Detail = new NavigationPage(new Home());
        }

        private async void btExcluir_Clicked(object sender, EventArgs e)
        {
            var resp = await DisplayAlert("Excluir registro?",
                                          "Deseja exluir a nota atual?",
                                          "Sim", "Não");
            if (resp==true)
            {
                ServicesDBNotas dbNotas = new ServicesDBNotas(App.dbPath);
                int id = Convert.ToInt32(lbCodigo.Text);
                dbNotas.Excluir(id);
                DisplayAlert("Rsultado da operação", dbNotas.StatusMessage, "OK");
                FlyoutPage p = (FlyoutPage)Application.Current.MainPage;
                p.Detail = new NavigationPage(new Home());
            }
        }
    }
}