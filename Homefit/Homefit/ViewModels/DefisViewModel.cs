using Homefit.Models;
using Homefit.ViewModels.Base;
using Homefit.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Homefit.ViewModels
{
    public class DefisViewModel : BaseViewModel
    {
        private int height;
        public int Height
        {
            get { return height; }
            set { SetProperty(ref height, value); }
        }
        public INavigation Navigation { get; set; }

        private List<Defis> defis = new List<Defis>();
        public List<Defis> Defis
        {
            get { return defis; }
            set
            {
                SetProperty(ref defis, value);
                Height = (Defis.Count * 50);
            }
        }
        public ICommand DetailViewCommand => new Command(ExecuteDetailViewCommandAsync);
        private async void ExecuteDetailViewCommandAsync(object obj)
        {
            var item = (Models.Defis)obj;
            Navigation.PushAsync(new DetailDefisView(item));
        }
        public DefisViewModel()
        {
            GetDefis();
        }
        public async void GetDefis()
        {
            var apiResponse = await App.Client.GetDefisAsync();
            Defis = apiResponse.Liste;
            

        }
    }
}
