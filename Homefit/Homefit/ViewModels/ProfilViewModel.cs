using Homefit.Enum;
using Homefit.Interfaces;
using Homefit.Models;
using Homefit.ViewModels.Base;
using Homefit.Views;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;
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
       
        public INavigation Navigation { get; set; }

        private Utilisateur compteCo;
        public Utilisateur CompteConnect
        {
            get { return compteCo; }
            set { SetProperty(ref compteCo, value); }
        }
        private List<Materiel> materiels = new List<Materiel>();
        public List<Materiel> Materiels
        {
            get { return materiels; }
            set
            {
                SetProperty(ref materiels, value);
            }
        }
        public ICommand DeconnexionCommand => new Command(ExecuteDeconnexionCommand);

        private async void ExecuteDeconnexionCommand(object obj)
        {
            
            CompteConnect.IsConnect = 0;
            await App.DataBase.UpdateUtilisateurAsync(CompteConnect);
            _navigationService.SetCurrentPage(new NavigationPage( new ConnexionView()));
        }
        public ICommand UpdateCommandButton => new Command(ExecuteUpdateCommand);

        private async void ExecuteUpdateCommand(object obj)
        {

            await Navigation.PushAsync(new UpdateProfilView());
           
        }
        private string objectifs;
        public string Objectifs
        {
            get { return objectifs; }
            set { SetProperty(ref objectifs, value); }
        }
        private ImageSource photo;
        public ImageSource Photo
        {
            get { return photo; }
            set { SetProperty(ref photo, value); }
        }
        public ICommand TakePicktureCommand => new Command(TakePicture);
        private async void TakePicture()
        {
            Stream stream = await DependencyService.Get<IPhotoPickerService>().GetImageStreamAsync();
            string uri = DependencyService.Get<IPhotoPickerService>().GetUriAsync();
            if (stream != null)
            {
                
                //Photo = ImageSource.FromStream(() => stream);
                Photo = ImageSource.FromFile(uri);
                // StreamReader reader = new StreamReader(stream);
                //Photo = ImageSource.FromStream(() => GetStream(uri));
               // stream.Dispose();
                //DependencyService.Get<IPhotoPickerService>().SavePicture("ProfilPicture.jpg", stream, "imagesFolder");
                /* StreamReader reader = new StreamReader(stream);
                  CompteConnect.Photo = Convert.ToBase64String(ReadFully(stream));

                  await App.DataBase.UpdateUtilisateurAsync(CompteConnect);*/
            }
        }
        protected Stream GetStream(String gazouUrl)
        {
            HttpWebRequest aRequest = (HttpWebRequest)WebRequest.Create(gazouUrl);
            HttpWebResponse aResponse = (HttpWebResponse)aRequest.GetResponse();

            return aResponse.GetResponseStream();
        }
        public ProfilViewModel()
        {
            MessagingCenter.Subscribe<UpdateProfilViewModel>(this, "RefreshView", (sender) =>
            {
                GetUtilisateur();
            });
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
            var apiR = await App.Client.GetUtilisateurMaterielsAsync(CompteConnect.Id);
            if(apiR.Counter > 0)
            {
                Materiels = apiR.Liste;
            }
            if(CompteConnect.Ojectifs != "" && CompteConnect.Ojectifs != null)
            {
                Objectifs = Enumerations.GetEnumDescription(CompteConnect.Ojectifs);
            }
            else
            {
                Objectifs = "-";
            }
            Photo = ImageSource.FromFile("gymnast"+CompteConnect.Sexe+".png");
        }
    }
}
