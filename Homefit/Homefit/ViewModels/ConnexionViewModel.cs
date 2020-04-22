﻿using Homefit.Models;
using Homefit.Services;
using Homefit.ViewModels.Base;
using Homefit.Views;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Homefit.ViewModels
{
    public class ConnexionViewModel : BaseViewModel
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
        public ICommand ConnexionButtonClickedCommand => new Command(ExecuteConnexionButtonClickedCommandAsync);
        public ICommand InscriptionCommand => new Command(ExecuteNewInscriptionClickedCommand);

        private void ExecuteNewInscriptionClickedCommand(object obj)
        {
            Device.BeginInvokeOnMainThread(async () => {
                await Application.Current.MainPage.Navigation.PushAsync(new InscriptionView());
            });
        }

        private async void ExecuteConnexionButtonClickedCommandAsync(object obj)
        {
            var current = Connectivity.NetworkAccess;

            Utilisateur utilisateur = await App.DataBase.GetUtilisateurAsync(Email);
            if (utilisateur != null)
            {
                if (utilisateur.Password == Password)
                {
                    utilisateur.IsConnect = 1;
                    await App.DataBase.UpdateUtilisateurAsync(utilisateur);
                    _navigationService.SetCurrentPage(new MainPage(utilisateur));
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("ERREUR", "Mot de passe incorect", "Ok");
                }
            }
            else 
            {
                if (current == NetworkAccess.Internet)
                {

                    try
                    {
                        var client = HttpService.GetInstance();
                        var result = await client.GetAsync($"https://thedamteam.fr/api/utilisateurs");
                        var serializedResponse = await result.Content.ReadAsStringAsync();
                        var apiResponse = JsonConvert.DeserializeObject<UtilisateurResponse>(serializedResponse);
                        if(apiResponse.Counter > 0)
                        {
                            bool find = false;
                            int i = 0;
                            while (!find &&  i < apiResponse.Counter)
                            {
                                if(apiResponse.Utilisateurs[i].Email == Email && apiResponse.Utilisateurs[i].Password ==  Password)
                                {
                                    find = true;
                                }
                                else
                                {
                                    i++;
                                }
                                
                            }
                            if(find)
                            {
                                Utilisateur mUtilisateur = new Utilisateur();
                                mUtilisateur = apiResponse.Utilisateurs[i];
                                mUtilisateur.IsConnect = 1;
                                await App.DataBase.SaveUtilisateurAsync(mUtilisateur);
                                _navigationService.SetCurrentPage(new MainPage(mUtilisateur));
                            }
                            else
                            {
                                await Application.Current.MainPage.DisplayAlert("ERREUR", "Ce compte n'existe pas", "Ok");
                            }
                        }
                        else
                        {
                            await Application.Current.MainPage.DisplayAlert("ERREUR", "Il n'existe pas de compte, veuillez vous inscrire", "Ok");
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("{0} Exception caught.", ex);

                    }
                    finally
                    {
                        IsBusy = false;
                    }
                }
                else // sinon
                {
                    await Application.Current.MainPage.DisplayAlert("ERREUR", "Veuillez activer internet avant de continuer", "Ok");
                }
            } 
        }
        public async Task ExecuteInitialBDD()
        {
            if (IsBusy)
                return;

            IsBusy = true;
            IsEmpty = false;

            try
            {

                Utilisateur utilisateur = await App.DataBase.GetUtilisateurAsync("test");
                if (utilisateur == null)
                {
                    await App.DataBase.SaveUtilisateurAsync(new Utilisateur("test", "test"));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("{0} Exception caught.", ex);

            }
            finally
            {
                IsBusy = false;
            }
            

            
            
        }
        public ConnexionViewModel()
        {
            
            Device.BeginInvokeOnMainThread(async () =>
            {
                
                Utilisateur utilisateur = await App.DataBase.GetUtilisateurIsConnect();
                if (utilisateur != null)
                {
                    if (utilisateur.IsConnect == 1)
                    {
                        _navigationService.SetCurrentPage(new MainPage(utilisateur));
                    }
                }
            });
        }
    }
}
