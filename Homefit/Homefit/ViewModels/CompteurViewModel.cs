using Homefit.Models;
using Homefit.ViewModels.Base;
using Homefit.Views;
using System;
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
                    Navigation.PushAsync(new JouerDefisView(Defis));
                }
            }
        }

        private Defis defis;
        public Defis Defis
        {
            get { return defis; }
            set { SetProperty(ref defis, value); }
        }

        public CompteurViewModel(Defis defis)
        {
            Defis = defis;
            Device.StartTimer(TimeSpan.FromSeconds(1), () =>
            {
                Compteur--;
                if (Compteur == 0)
                {
                    return false;
                }
                return true;
            });
        }

    }
}
