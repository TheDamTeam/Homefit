using Homefit.Models;
using Homefit.Services;
using Homefit.Services.Http;
using Homefit.ViewModels.Base;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Homefit.ViewModels
{
    public class ProgrammeDayViewModel : BaseViewModel
    {
        #region Properties

        private int currentDayNb;
        public int CurrentDayNb
        {
            get { return currentDayNb; }
            set { SetProperty(ref currentDayNb, value); }
        }

        private bool participe;
        public bool Participe
        {
            get { return participe; }
            set { SetProperty(ref participe, value); }
        }
        //List<Repas> repas = new List<Repas>();
        //ProgrammeNutrition currentProgramme;

        public INavigation Navigation { get; set; }

        public bool isRefreshing = false;
        public bool IsRefreshing
        {
            get { return isRefreshing; }
            set { SetProperty(ref isRefreshing, value); }
        }

        private string contentLabel = "Jour ";
        public string ContentLabel
        {
            get { return contentLabel; }
            set { SetProperty(ref contentLabel, value); }
        }

        private List<Aliment> ptiDej = new List<Aliment>();
        public List<Aliment> PtiDej
        {
            get { return ptiDej; }
            set
            { 
                SetProperty(ref ptiDej, value);
                Height = (PtiDej.Count * 30);
            }
        }

        private List<Aliment> diner = new List<Aliment>();
        public List<Aliment> Diner
        {
            get { return diner; }
            set 
            { 
                SetProperty(ref diner, value);
                Height = (Diner.Count * 30);
            }
        }

        private List<Aliment> dejeuner = new List<Aliment>();
        public List<Aliment> Dejeuner
        {
            get { return dejeuner; }
            set 
            { 
                SetProperty(ref dejeuner, value);
                Height = (Dejeuner.Count * 30);
            }
        }

        private List<Aliment> collation = new List<Aliment>();
        public List<Aliment> Collation
        {
            get { return collation; }
            set 
            { 
                SetProperty(ref collation, value);               
                Height = (Collation.Count * 30);
            }
        }

        private string dayNb;
        public string DayNb
        {
            get { return dayNb; }
            set { SetProperty(ref dayNb, value); }
        }

        private int height;
        public int Height
        {
            get { return height; }
            set { SetProperty(ref height, value); }
        }
        #endregion

        public ProgrammeDayViewModel(int dayNb)
        {            
            Participe = false;
            DayNb = "";
            CurrentDayNb = dayNb;
            ContentLabel += dayNb;
            DayNb = "Jour " + dayNb;
            LoadRepas();         
        }

        public async void LoadRepas()
        {
            var apiResponse = await App.Client.GetRepasAsync();
            if (apiResponse.Counter > 0)
            {
                var LesRepas = apiResponse.Liste;
                foreach (Repas r in LesRepas)
                {
                    if (r.Jour == CurrentDayNb)
                    {
                        var apiCategorie = await App.Client.GetRepasCategorieAsync(r.Id);
                        if (apiCategorie.Counter > 0)
                        {
                            var cat = apiCategorie.Liste;
                            var apiAliment = await App.Client.GetRepasAlimentAsync(r.Id);
                            switch(cat[0].Libelle)
                            {
                                case "Petit déjeuner":
                                    PtiDej = apiAliment.Liste;                                    
                                    break;
                                case "Diner":
                                    Diner = apiAliment.Liste;
                                    break;
                                case "Déjeuner":
                                    Dejeuner = apiAliment.Liste;
                                    break;
                                case "Collation":
                                    Collation = apiAliment.Liste;                                   
                                    break;
                                default:
                                    break;
                            }
                        }
                    }
                }
            }          
        }
    }
}
