using Android.Content;
using Android.Widget;
using Homefit.Models;
using Homefit.Models.ApiResponse;
using Homefit.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Homefit.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ProgrammeSportifDetail : ContentPage
	{
        public static int i;

        public ProgrammeSportifDetail (int idSelected)
		{
			InitializeComponent ();
            Load(idSelected);

            i = idSelected;

    }
        async void OnButtonClicked(object sender, EventArgs args)
            {
                Participe(i);
            await Application.Current.MainPage.DisplayAlert("🏋️Participation !🏋️", "Votre participation au programme a était enregistré", "Ok");

        }
        protected async void Load(int idSelected)
        {
            var APIResponse = await App.Client.GetEntrainementAsync(idSelected);
            laputaindeliste.ItemsSource = APIResponse.Liste;
        }

        protected async void Participe(int idSelected)
        {
            var userConnected = await App.DataBase.GetUtilisateurIsConnect();
            Debug.WriteLine("IDUSER= " + userConnected.Id);
            Debug.WriteLine("IDPROGRAMME= " + idSelected);
            DateTime now = DateTime.Now;
            ParticiperProgrammeSportif participerProgramme = new ParticiperProgrammeSportif(now, "/api/utilisateurs/" + userConnected.Id, "/api/programme_sportifs/" + idSelected);
            var isOk = await App.Client.ParticipeProgrammeSportifAsync(participerProgramme);
            Debug.WriteLine("ITSOKKKK= " + isOk);
        }


    }
}