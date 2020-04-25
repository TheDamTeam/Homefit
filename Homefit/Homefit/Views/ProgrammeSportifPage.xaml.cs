using System.Collections.Generic;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Homefit.Models;
using Xamarin.Forms.Internals;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Input;
using Newtonsoft.Json;
using System.Diagnostics;
using Homefit.Models.ApiResponse;
using Homefit.Services;

namespace Homefit.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]

    public partial class ProgrammeSportifPage : ContentPage
    {

        public ProgrammeSportifPage()
        {
            InitializeComponent();
            Load();
         }

        public async void lvItemTapped(object sender, ItemTappedEventArgs e) {
            var content = e.Item as ProgrammeSportif;
            Debug.WriteLine("ID :" + content.Id);
            await Navigation.PushAsync(new ProgrammeSportifDetail(content.Id));
        }

      

     
            protected async void Load()
            {
                var APIResponse = await App.Client.GetProgrammeSportifAsync();
                laputaindeliste.ItemsSource = APIResponse.ProgrammeSportifs;
            }


        

    }

}

   
