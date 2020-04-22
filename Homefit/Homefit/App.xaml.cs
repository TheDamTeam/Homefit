using Homefit.Services.Data;
using Homefit.Services.Navigation;
using Homefit.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Homefit
{
    public partial class App : Application
    {
        static DataBase dataBase;
        public static DataBase DataBase
        {
            get
            {
                if (dataBase == null)
                {
                    dataBase = new DataBase();
                }
                return dataBase;
            }
        }
        public App()
        {
            InitializeComponent();
            DependencyService.Register<INavigationService, NavigationService>();
            MainPage = new NavigationPage(new ConnexionView());
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
