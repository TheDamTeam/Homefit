using Homefit.Enum;
using Homefit.Models;
using Homefit.ViewModels.Base;
using Homefit.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Homefit.ViewModels
{
    public class UpdateProfilViewModel : BaseViewModel
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
        private string sexeText;
        public string SexeText
        {
            get { return sexeText; }
            set { SetProperty(ref sexeText, value);}
        }
        private Objectif objectifs ;
        public Objectif Objectifs
        {
            get { return objectifs;}
            set { SetProperty(ref objectifs, value); }
        }
        private string taille;
        public string Taille
        {
            get { return taille; }
            set { SetProperty(ref taille, value); }
        }
        private string poids;
        private Utilisateur compteCo;
        public Utilisateur CompteConnect
        {
            get { return compteCo; }
            set { SetProperty(ref compteCo, value); }
        }
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
        private int height;
        public int Height
        {
            get{ return height; }
            set{ SetProperty(ref height, value); }
        }
        public INavigation Navigation { get; set; }
        private List<Materiel> materiels = new List<Materiel>();
        public List<Materiel> Materiels
        {
            get { return materiels; }
            set { SetProperty(ref materiels, value);
                Height = (Materiels.Count * 40) + (Materiels.Count * 10);
            }
        }
        public ICommand UpdateButtonClickedCommand => new Command(ExecuteUpdateClickedCommandAsync);
        private async void ExecuteUpdateClickedCommandAsync(object obj)
        {
            IsBusy = true;
            try
            {
                Utilisateur item = new Utilisateur(Email, Password, Nom, Prenom, DateNaiss, float.Parse(Poids), int.Parse(Taille), SexeText,Objectifs.GetDescription());
                foreach(Materiel m in Materiels)
                {
                    if(m.AvoirMateriel == true)
                    {
                        item.Materiels.Add("/api/materiels/"+ m.Id);
                    }
                }
                var apiResponse = await App.Client.SaveUtilisateurAsync(item, false,CompteConnect.Id);
                if (apiResponse)
                {
                    await Application.Current.MainPage.DisplayAlert("Modification", "Votre compte a été mis a jour", "Ok");

                    item.Id = CompteConnect.Id;
                    item.IsConnect = 1;
                    await App.DataBase.UpdateUtilisateurAsync(item);
                    MessagingCenter.Send(this, "RefreshView");
                    await Navigation.PopAsync();
                    
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

        public UpdateProfilViewModel()
        {
            
            GetUtilisateur();
        }
        
        public async void GetUtilisateur()
        {
            CompteConnect = await App.DataBase.GetUtilisateurIsConnect();
            Taille = CompteConnect.Taille.ToString();
            Poids = CompteConnect.Poids.ToString();
            DateNaiss = CompteConnect.DateNaiss;
            Nom = CompteConnect.Nom;
            Prenom = CompteConnect.Prenom;
            Email = CompteConnect.Email;
            Password = CompteConnect.Password;
            if (CompteConnect.Ojectifs != "" && CompteConnect.Ojectifs != null)
            {
                Objectifs = Enumerations.GetEnumByDescription(Enumerations.GetEnumDescription(CompteConnect.Ojectifs));
            }
            
            if (CompteConnect.Sexe == "Femme")
            {
                Sexe = true;
            }
            else
            {
                Sexe = false;
            }
            GetMateriel();
        }
        public async void GetMateriel()
        {
            var apiResponse = await App.Client.GetUtilisateurMaterielsAsync(CompteConnect.Id);
            CompteConnect.MyMateriels = apiResponse.Liste;
            apiResponse = await App.Client.GetMaterielsAsync();
            foreach (Materiel m in apiResponse.Liste)
            {
                if (CompteConnect.MyMateriels.Exists(x => x.Id == m.Id))
                {
                    m.AvoirMateriel = true;
                }
                else
                {
                    m.AvoirMateriel = false;
                }
            }
            Materiels = apiResponse.Liste;

            
            
           
        }
    }
}
