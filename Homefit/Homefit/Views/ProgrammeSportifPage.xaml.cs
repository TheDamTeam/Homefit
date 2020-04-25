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
      //  ProgrammeSportif programmeSportifJambe = new ProgrammeSportif("Jambes");
      //  ProgrammeSportif programmeSportifHDC = new ProgrammeSportif("Haut du corp");
      //  ProgrammeSportif programmeSportifCardio = new ProgrammeSportif("Cardio");
        List<ProgrammeSportif> listedeprogrammes { get; set; }


        private HttpClient client = new HttpClient();



        public ProgrammeSportifPage()
        {
            InitializeComponent();

            listedeprogrammes = new List<ProgrammeSportif>();

            Load();


    }

        public async void lvItemTapped(object sender, ItemTappedEventArgs e) {
  

            var content = e.Item as ProgrammeSportif;


            Debug.WriteLine("ID :" + content.Id);
            await Navigation.PushAsync(new ProgrammeSportifDetail(content.Id));
        }

      

        protected async void Load()
        {

            try {
                var client = HttpService.GetInstance();
                var result = await client.GetAsync($"https://www.thedamteam.fr/api/programme_sportifs/");
                var serializedResponse = await result.Content.ReadAsStringAsync();

                // var result = await client.GetStringAsync("http://www.thedamteam.fr/api/programme_sportifs/");


                var APIResponse = JsonConvert.DeserializeObject<ProgrammeSportifResponse>(serializedResponse);
                Debug.WriteLine("FONCTIONNE" + APIResponse);
                laputaindeliste.ItemsSource = APIResponse.ProgrammeSportifs;
           
            }
            catch (Exception ey)
                {
                    Debug.WriteLine("NOTFONCTIONNE" + ey);
                }

}

    }

}

   
