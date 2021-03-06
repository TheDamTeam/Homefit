﻿using Homefit.Models;
using Homefit.ViewModels.Base;
using Homefit.Views;
using System;
using System.Collections.Generic;
using System.Windows.Input;
using Xamarin.Forms;

namespace Homefit.ViewModels
{
    public class DetailDefisViewModel : BaseViewModel
    {
        #region Properties       
        public INavigation Navigation { get; set; }

        private Defis defis;
        public Defis Defis
        {
            get { return defis; }
            set { SetProperty(ref defis, value); }
        }

        private string description;
        public string Description
        {
            get { return description; }
            set { SetProperty(ref description, value); }
        }

        private DateTime duree;
        public DateTime Duree
        {
            get { return duree; }
            set { SetProperty(ref duree, value); }
        }

        private int height;
        public int Height
        {
            get { return height; }
            set { SetProperty(ref height, value); }
        }
        private string devise;
        public string Devise
        {
            get { return devise; }
            set { SetProperty(ref devise, value); }
        }
        private string libelle;
        public string Libelle
        {
            get { return libelle; }
            set { SetProperty(ref libelle, value); }
        }

        private string defiName;
        public string DefiName
        {
            get { return defiName; }
            set { SetProperty(ref defiName, value); }
        }

        private List<Classement> classements;
        public List<Classement> Classement
        {
            get { return classements; }
            set
            {
                SetProperty(ref classements, value);
                Height = (Classement.Count * 50);
            }
        }
        #endregion

        #region Commands     
        public ICommand ParticiperCommandButton => new Command(ExecuteClickedCommandAsync);
        #endregion

        public DetailDefisViewModel(Defis defisParam)
        {
            Defis = defisParam;
            MessagingCenter.Subscribe<JouerDefisViewModel>(this, "RefreshView", (sender) =>
            {
                GetInformationViewModel();
            });
            GetInformationViewModel();
            Title = $"{defis.Libelle}";
        }

        #region ExecuteCommands       
        private void ExecuteClickedCommandAsync(object obj)
        {
            Navigation.PushAsync(new CompteurView(Defis));
        }

        private async void GetInformationViewModel()
        {
            Description = Defis.Description;
            Duree = Defis.Duree;
            Libelle = Defis.Libelle;
            if (Duree.Minute < 1)
            {
                Devise = "secondes";
            }
            else
            {
                Devise = "minutes";
            }
            var apiResponse = await App.Client.GetClassement(Defis.Id);
            Classement = apiResponse.Liste;
            for (int i = 0; i < Classement.Count; i++)
            {
                Classement[i].Position = i + 1;
                Classement[i].DefiName = Libelle;
            }
        }
        #endregion
    }
}
