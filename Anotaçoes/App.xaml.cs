using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Anotaçoes.Views;

namespace Anotaçoes
{
    public partial class App : Application
    {
        public static string dbName;
        public static string dbPath;
        public App()
        {
            InitializeComponent();

            MainPage = new PaginaPrincipal();
        }

        public App(string dbPath, string dbName)
        {
            InitializeComponent();
            App.dbName= dbName;
            App.dbPath = dbPath;
            MainPage = new PaginaPrincipal();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
