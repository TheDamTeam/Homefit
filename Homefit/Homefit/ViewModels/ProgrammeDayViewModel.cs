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
        string contentLabel = "Jour ";
        string dayNb;
        int currentDayNb;
        bool participe;

        private List<Aliment> ptiDej = new List<Aliment>();
        List<Aliment> diner = new List<Aliment>();
        List<Aliment> dejeuner = new List<Aliment>();
        List<Aliment> collation = new List<Aliment>();
        List<Repas> repas = new List<Repas>();

        ProgrammeNutrition currentProgramme;

        public INavigation Navigation { get; set; }
        public string ContentLabel
        {
            get { return contentLabel; }
            set { SetProperty(ref contentLabel, value); }
        }

        public List<Aliment> PtiDej
        {
            get { return ptiDej; }
            set { SetProperty(ref ptiDej, value); }
        }

        public List<Aliment> Diner
        {
            get { return diner; }
            set { SetProperty(ref diner, value); }
        }

        public List<Aliment> Dejeuner
        {
            get { return dejeuner; }
            set { SetProperty(ref dejeuner, value); }
        }

        public List<Aliment> Collation
        {
            get { return collation; }
            set { SetProperty(ref collation, value); }
        }



        public string DayNb
        {
            get { return dayNb; }
            set { SetProperty(ref dayNb, value); }
        }

        public ProgrammeDayViewModel(int dayNb)
        {
            this.participe = false;
            this.dayNb = "";
            this.currentDayNb = dayNb;
            contentLabel += dayNb;
            this.dayNb = "Jour " + dayNb;
            LoadRepas();
            //PtiDej.Add(new Aliment() { AlimentName = "banane", Calorie = 100, Glucide = 10 });
            //PtiDej.Add(new Aliment() { AlimentName = "Pomme", Calorie = 100, Glucide = 10 });
        }

        public async void LoadRepas()
        {
            var apiResponse = await App.Client.GetRepasAsync();
            if (apiResponse.Counter > 0)
            {
                var LesRepas = apiResponse.Liste;
                foreach (Repas r in LesRepas)
                {
                    if (r.Jour == currentDayNb)
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
