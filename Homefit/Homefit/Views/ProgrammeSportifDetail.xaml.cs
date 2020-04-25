using Homefit.Models.ApiResponse;
using Homefit.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Homefit.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ProgrammeSportifDetail : ContentPage
	{
		public ProgrammeSportifDetail (int idSelected)
		{
			InitializeComponent ();
           // int idSelected = Int32.Parse(v);
            Load(idSelected);
            
        }


        protected async void Load(int idSelected)
        {

            try
            {
                var client = HttpService.GetInstance();
                var result = await client.GetAsync($" https://www.thedamteam.fr/api/programme_sportif/"+ idSelected + "/entrainements");
                var serializedResponse = await result.Content.ReadAsStringAsync();

                // var result = await client.GetStringAsync("http://www.thedamteam.fr/api/programme_sportifs/");


                var APIResponse = JsonConvert.DeserializeObject<EntrainementResponse>(serializedResponse);
                Debug.WriteLine("FONCTIONNE" + APIResponse.Entrainements[idSelected].EntrainementName);
                laputaindeliste.ItemsSource = APIResponse.Entrainements;
             Debug.WriteLine("COUNT" + APIResponse.Entrainements.Count);

            }
            catch (Exception ey)
            {
                Debug.WriteLine("NOTFONCTIONNE" + ey);
            }

        }
    }
}