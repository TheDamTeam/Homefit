using Homefit.Models;
using Homefit.Services;
using Homefit.Services.Http;
using Homefit.ViewModels.Base;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Homefit.ViewModels
{
    public class ProgrammeDayViewModel : BaseViewModel
    {
        string contentLabel = "Jour ";
        string dayNb;
        List<Repas> ptiDej = new List<Repas>();
        List<Repas> diner = new List<Repas>();
        List<Repas> dejeuner = new List<Repas>();
        List<Repas> collation = new List<Repas>();
        DateTime currentDate = DateTime.Now;
        public string ContentLabel
        {
            get { return contentLabel; }
            set { SetProperty(ref contentLabel, value); }
        }

        public string DayNb
        {
            get { return dayNb; }
            set { SetProperty(ref dayNb, value); }
        }

        public ProgrammeDayViewModel(int dayNb)
        {
            this.dayNb = "";
            contentLabel += dayNb;
            this.dayNb = "Jour " + dayNb;
            loadRepas();
        }

        public async void loadRepas()
        {
            var apiResponse = await App.Client.GetRepasAsync();
                if (apiResponse.Counter > 0)
            {
                var repas = apiResponse.Repas;
                repas.ForEach(x =>
                {
                    
                    //date
                    if (x.DateRepas.Month.Equals(DateTime.Now.Month) && x.DateRepas.Day.Equals(DateTime.Now.Day))
                    {
                        //categorie
                        if (x.DateRepas.Equals(currentDate))
                        {
                            diner.Add(x);
                        }
                    }
                });
            }
        }

        public async void loadRepasCategorie(int id)
        {
            var apiResponse = await App.Client.GetRepasCategorieAsync(id);
            if (apiResponse.Counter > 0)
            {
                var repasCategorie = apiResponse.Libelle;
            }
        }

    }
}
