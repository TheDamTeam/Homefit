﻿using Homefit.Models;
using Homefit.ViewModels.Base;

namespace Homefit.ViewModels
{
    public class MainPageViewModel : BaseViewModel
    {
        private Utilisateur compteCo;
        public Utilisateur CompteConnect
        {
            get { return compteCo; }
            set { SetProperty(ref compteCo, value); }
        }
        public MainPageViewModel(Utilisateur compte)
        {
            CompteConnect = compte;
        }
        public MainPageViewModel()
        {

        }
    }
}
