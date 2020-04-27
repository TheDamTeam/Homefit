using Homefit.Models;
using Homefit.ViewModels.Base;
using Homefit.Views;
using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace Homefit.ViewModels
{
    public class InscriptionViewModel : BaseViewModel
    {
        #region Properties
        private string email;
        public string Email
        {
            get { return email; }
            set { SetProperty(ref email, value); }
        }
        private string password;
        public string Password
        {
            get { return password; }
            set { SetProperty(ref password, value); }
        }
        private string nom;
        public string Nom
        {
            get { return nom; }
            set { SetProperty(ref nom, value); }
        }
        private string prenom;
        public string Prenom
        {
            get { return prenom; }
            set { SetProperty(ref prenom, value); }
        }
        private string sexeText;
        public string SexeText
        {
            get { return sexeText; }
            set { SetProperty(ref sexeText, value); }
        }
        private string taille;
        public string Taille
        {
            get { return taille; }
            set { SetProperty(ref taille, value); }
        }
        private string poids;
        public string Poids
        {
            get { return poids; }
            set { SetProperty(ref poids, value); }
        }
        private DateTime dateNaiss;
        public DateTime DateNaiss
        {
            get { return dateNaiss; }
            set { SetProperty(ref dateNaiss, value); }
        }
        private bool sexe;
        public bool Sexe
        {
            get { return sexe; }
            set
            {
                SetProperty(ref sexe, value);
                if (Sexe)
                {
                    SexeText = "Femme";
                }
                else
                {
                    SexeText = "Homme";
                }
            }
        }
        #endregion

        #region Commands
        public ICommand InscriptionButtonClickedCommand => new Command(ExecuteInscriptionClickedCommandAsync);
        #endregion

        public InscriptionViewModel()
        {
            Sexe = false;
            SexeText = "Homme";
        }

        #region ExecuteCommands
        private async void ExecuteInscriptionClickedCommandAsync(object obj)
        {
            IsBusy = true;
            try
            {
                Utilisateur item = new Utilisateur(Email, Password, Nom, Prenom, DateNaiss, float.Parse(Poids), int.Parse(Taille), SexeText, "");
                var apiResponse = await App.Client.SaveUtilisateurAsync(item, true);
                if (apiResponse)
                {
                    await Application.Current.MainPage.DisplayAlert("Bienvenue", "Votre compte a été crée avec succès", "Ok");
                    var apiRep = await App.Client.GetUtilisateursAsync();
                    if (apiRep.Counter > 0)
                    {
                        bool find = false;
                        int i = 0;
                        while (!find && i < apiRep.Counter)
                        {
                            if (apiRep.Liste[i].Email == Email && apiRep.Liste[i].Password == Password)
                            {
                                find = true;
                            }
                            else
                            {
                                i++;
                            }

                        }
                        if (find)
                        {
                            Utilisateur mUtilisateur = apiRep.Liste[i];
                            mUtilisateur.IsConnect = 1;
                            await App.DataBase.SaveUtilisateurAsync(mUtilisateur);
                            _navigationService.SetCurrentPage(new MainPage(mUtilisateur));
                        }
                    }
                    _navigationService.SetCurrentPage(new MainPage(item));
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("ERREUR", "Une erreur c'est produite veuillez réessayer plus tard", "Ok");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("{0} Exception caught.", ex);
                await Application.Current.MainPage.DisplayAlert("ERREUR", "Veuillez remplir les champs avant de valider", "Ok");

            }
            finally
            {
                IsBusy = false;
            }

        }
        #endregion
    }
}
