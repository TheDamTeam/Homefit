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
            Load(idSelected);
        }

        protected async void Load(int idSelected)
        {
            var APIResponse = await App.Client.GetEntrainementAsync(idSelected);
            laputaindeliste.ItemsSource = APIResponse.Entrainements;
        }
    }
}