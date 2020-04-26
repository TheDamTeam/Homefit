using Homefit.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Homefit.ViewModels
{
    public class CompteurViewModel : BaseViewModel
    {
        public INavigation Navigation { get; set; }
        private int compteur = 3;
        public int Compteur
        {
            get { return compteur; }
            set 
            { 
             
                SetProperty(ref compteur, value);
                if (Compteur == 0)
                {
                    Navigation.PopAsync();
                    Alert();
                }
            }
        }
        public CompteurViewModel()
        {
            Device.StartTimer(TimeSpan.FromSeconds(1), () =>
            {
                Compteur--;
                if(Compteur == 0)
                {
                    return false;
                }
                return true;
             });

        }
        private async void Alert()
        {
            
            string result = await Application.Current.MainPage.DisplayPromptAsync("Score", "Quel est votre score ?");
        }
    }
}
