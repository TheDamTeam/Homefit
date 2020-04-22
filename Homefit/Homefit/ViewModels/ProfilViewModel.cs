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
    public class ProfilViewModel : BaseViewModel
    {
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
        private string nomPrenom;
        public string NomPrenom
        {
            get { return nomPrenom; }
            set { SetProperty(ref nomPrenom, value); }
        }
        private DateTime dateNaiss;
        public DateTime DateNaiss
        {
            get { return dateNaiss; }
            set { SetProperty(ref dateNaiss,value); }
        }
        private string sexe;
        public string Sexe
        {
            get { return sexe; }
            set { SetProperty(ref sexe, value); }
        }
        private string photo;
        public string Photo
        {
            get { return photo; }
            set { SetProperty(ref photo, value); }
        }
        public INavigation Navigation { get; set; }

        private Utilisateur compteCo;
        public Utilisateur CompteConnect
        {
            get { return compteCo; }
            set { SetProperty(ref compteCo, value); }
        }

        public ICommand DeconnexionCommand => new Command(ExecuteDeconnexionCommand);

        private async void ExecuteDeconnexionCommand(object obj)
        {
            
            CompteConnect.IsConnect = 0;
            await App.DataBase.UpdateUtilisateurAsync(CompteConnect);
            _navigationService.SetCurrentPage(new ConnexionView());
        }
        public ICommand UpdateCommandButton => new Command(ExecuteUpdateCommand);

        private async void ExecuteUpdateCommand(object obj)
        {

            await Navigation.PushAsync(new UpdateProfilView());
           
        }

        public ProfilViewModel()
        {
            GetUtilisateur();
        }
        public async void GetUtilisateur()
        {
            CompteConnect = await App.DataBase.GetUtilisateurIsConnect();
            Taille =  CompteConnect.Taille.ToString();
            Poids = CompteConnect.Poids.ToString();
            DateNaiss = CompteConnect.DateNaiss;
            NomPrenom = CompteConnect.Prenom+" "+CompteConnect.Nom;
            Sexe = CompteConnect.Sexe;
            if(Sexe == "masculin")
            {
                Photo = "gymnast_homme.png";
            }
            else
            {
                Photo = "gymnast_femme.png";
            }
        }
    }
}
