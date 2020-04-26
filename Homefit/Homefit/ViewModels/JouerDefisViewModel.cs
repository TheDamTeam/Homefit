using Homefit.Models;
using Homefit.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Xamarin.Forms;

namespace Homefit.ViewModels
{
    public class JouerDefisViewModel : BaseViewModel
    {
        public INavigation Navigation { get; set; }
        private Defis defis;
        public Defis Defis
        {
            get { return defis; }
            set { SetProperty(ref defis, value); }
        }
        private string tempEcoule;
        public string TempEcoule
        {
            get { return tempEcoule; }
            set { SetProperty(ref tempEcoule, value); }
        }
        private Stopwatch stopwatch = new Stopwatch();

        private string libelle;
        public string Libelle
        {
            get { return libelle; }
            set { SetProperty(ref libelle, value); }
        }
        private string duree;
        public string Duree
        {
            get { return duree; }
            set { SetProperty(ref duree, value); }
        }
        private bool chrono = true;
        public bool Chrono
        {
            get { return chrono; }
            set
            {
                SetProperty(ref chrono, value);
                if (!Chrono)
                {
                    Alert();
                }
            }
        }
        public JouerDefisViewModel(Defis defis)
        {
            stopwatch.Start();

            Defis = defis;

            Libelle = Defis.Libelle;
            Duree = String.Format("{0:00}:{1:00}", defis.Duree.Minute, defis.Duree.Second);
            Device.StartTimer(TimeSpan.FromMilliseconds(100), () =>
            {
                TempEcoule = String.Format("{0:00}:{1:00}.{2:00}",
                stopwatch.Elapsed.Minutes, stopwatch.Elapsed.Seconds,
                stopwatch.Elapsed.Milliseconds / 10);
                if (TempEcoule.Contains(Duree))
                {
                    Chrono = false;
                }
                return Chrono;
            });
        }
        private async void Alert()
        {
            var utilisateur = await App.DataBase.GetUtilisateurIsConnect();
            string result = await Application.Current.MainPage.DisplayPromptAsync("Score", "Quel est votre score ?", keyboard: Keyboard.Numeric);
            ParticiperDefis participerDefis = new ParticiperDefis(DateTime.Now, "/api/utilisateurs/" + utilisateur.Id, "/api/defis/" + Defis.Id, Int32.Parse(result));
            var apiResponse = await App.Client.SaveParticiperDefisAsync(participerDefis);
            if (apiResponse)
            {
                await Application.Current.MainPage.DisplayAlert("Félicitation", "Vous venez de participer à ce défi", "Ok");
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("ERREUR", "Une erreur c'est produite veuillez réessayer plus tard", "Ok");
            }
        }
    }
}
