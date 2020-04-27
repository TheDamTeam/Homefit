using Homefit.Models;
using Homefit.ViewModels.Base;
using Homefit.Views;
using System.Collections.Generic;
using System.Windows.Input;
using Xamarin.Forms;

namespace Homefit.ViewModels
{
    public class DefisViewModel : BaseViewModel
    {
        #region Properties
        public INavigation Navigation { get; set; }

        private int height;
        public int Height
        {
            get { return height; }
            set { SetProperty(ref height, value); }
        }

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
        #endregion

        #region Commands
        public ICommand DetailViewCommand => new Command(ExecuteDetailViewCommandAsync);
        #endregion

        public DefisViewModel()
        {
            GetDefis();
        }

        #region ExecuteCommands       
        private void ExecuteDetailViewCommandAsync(object obj)
        {
            var item = (Models.Defis)obj;
            Navigation.PushAsync(new DetailDefisView(item));
        }

        public async void GetDefis()
        {
            var apiResponse = await App.Client.GetDefisAsync();
            Defis = apiResponse.Liste;
        }
        #endregion
    }
}
