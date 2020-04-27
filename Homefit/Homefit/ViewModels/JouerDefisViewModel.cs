using Homefit.Models;
using Homefit.ViewModels.Base;
using System;
using System.Diagnostics;
using Xamarin.Forms;

namespace Homefit.ViewModels
{
    public class JouerDefisViewModel : BaseViewModel
    {
        #region Properties 
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
        public Stopwatch Stopwatch
        {
            get { return stopwatch; }
            set { SetProperty(ref stopwatch, value); }
        }

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
        #endregion

        public JouerDefisViewModel(Defis defis)
        {
            Defis = defis;
            Title = $"Défi - {defis.Libelle}";
            Stopwatch.Start();
            Libelle = Defis.Libelle;
            Duree = String.Format("{0:00}:{1:00}", defis.Duree.Minute, defis.Duree.Second);
            Device.StartTimer(TimeSpan.FromMilliseconds(100), () =>
            {
                TempEcoule = String.Format("{0:00}:{1:00}.{2:00}",
                Stopwatch.Elapsed.Minutes, Stopwatch.Elapsed.Seconds,
                Stopwatch.Elapsed.Milliseconds / 10);
                if (TempEcoule.Contains(Duree))
                {
                    Chrono = false;
                    Stopwatch.Stop();
                }
                return Chrono;
            });
        }

        #region ExecuteCommands
        private async void Alert()
        {
            var utilisateur = await App.DataBase.GetUtilisateurIsConnect();
            string result = await Application.Current.MainPage.DisplayPromptAsync("Score", "Quel est votre score ?", keyboard: Keyboard.Numeric);
            if (result != null)
            {
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
            else
            {
                await Application.Current.MainPage.DisplayAlert("Information", "Vous venez d'annuler la participation au défi", "Ok");

            }
            MessagingCenter.Send(this, "RefreshView");
            Navigation.RemovePage(Navigation.NavigationStack[Navigation.NavigationStack.Count - 2]);
            await Navigation.PopAsync();

        }
        #endregion
    }
}
