using Homefit.Models;
using Homefit.Services;
using Homefit.ViewModels.Base;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Homefit.ViewModels
{
    public class InscriptionViewModel : BaseViewModel
    {
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
        private string sexe;
        public string Sexe
        {
            get { return sexe; }
            set { SetProperty(ref sexe, value); }
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
        public ICommand InscriptionButtonClickedCommand => new Command(ExecuteInscriptionClickedCommandAsync);

        private async void ExecuteInscriptionClickedCommandAsync(object obj)
        {
            var client = HttpService.GetInstance();

            Utilisateur item = new Utilisateur(Email, Password, Nom, Prenom, DateNaiss, float.Parse(Poids), int.Parse(Taille), Sexe);
            var json = JsonConvert.SerializeObject(item);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = null;

            response = await client.PostAsync($"https://thedamteam.fr/api/utilisateurs", content);
            if(response.IsSuccessStatusCode)
            {
                await Application.Current.MainPage.DisplayAlert("Bienvenue", "Votre compte a été crée avec succès", "Ok");
            }
        }
           
        public InscriptionViewModel()
        {

        }
    }
}
