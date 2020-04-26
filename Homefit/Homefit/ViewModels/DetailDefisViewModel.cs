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
    public class DetailDefisViewModel : BaseViewModel
    {
        public INavigation Navigation { get; set; }
        private Defis defis;
        public Defis Defis
        {
            get { return defis; }
            set { SetProperty(ref defis, value); }
        }
        public ICommand ParticiperCommandButton => new Command(ExecuteClickedCommandAsync);

        private void ExecuteClickedCommandAsync(object obj)
        {
            Navigation.PushAsync(new CompteurView());
        }

        private string description;
        public string Description
        {
            get { return description; }
            set { SetProperty(ref description, value); }
        }
        private DateTime duree;
        public DateTime Duree
        {
            get { return duree; }
            set { SetProperty(ref duree, value); }
        }
        private int height;
        public int Height
        {
            get { return height; }
            set { SetProperty(ref height, value); }
        }
        private List<Classement> classements;
        public List<Classement> Classement
        {
            get { return classements; }
            set 
            { 
                SetProperty(ref classements, value);
                Height = (Classement.Count * 50);
            }
        }
        public DetailDefisViewModel(Defis defisParam)
        {
            Defis = defisParam;
            GetInformationViewModel();
        }
        private async void GetInformationViewModel()
        {
            Description = Defis.Description;
            duree = Defis.Duree;
            var apiResponse = await App.Client.GetClassement(Defis.Id);
            Classement = apiResponse.Liste;
            for(int i = 0;i<Classement.Count;i++)
            {
                Classement[i].Position = i + 1;
            }
        }
    }
}
