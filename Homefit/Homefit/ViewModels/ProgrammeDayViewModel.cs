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

        List<Aliment> ptiDej = new List<Aliment>();
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
            loadRepas();
            //PtiDej.Add(new Aliment() { AlimentName = "banane", Calorie = 100, Glucide = 10 });
            //PtiDej.Add(new Aliment() { AlimentName = "Pomme", Calorie = 100, Glucide = 10 });
        }

        public async void loadRepas()
        {
            var apiResponse = await App.Client.GetRepasAsync();
            if (apiResponse.Counter > 0)
            {

                var repas = apiResponse.Liste;
 
                foreach(Repas x in repas)
                {
                    var repasCategorie = await App.Client.GetRepasCategorieAsync(x.Id);
                    if (repasCategorie.Counter > 0)
                    {
                        string currentRepasCategorie = repasCategorie.Liste[0].Libelle;
                        if (x.Jour == currentDayNb && currentRepasCategorie.Equals("Petit déjeuner"))
                        {
                            x.Aliments.ForEach(async a =>
                            {
                                var lenght = a.Length;
                                var id = a[lenght - 1];
                                var aliment = await App.Client.GetAlimentAsync(id.ToString());
                                Aliment currentAliment = new Aliment() { AlimentName = aliment.AlimentName, Calorie = aliment.Calorie, Glucide = aliment.Glucide, Proteine = aliment.Proteine, Quantite = aliment.Quantite };
                                PtiDej.Add(currentAliment);
                            });

                        }
                        if (x.Jour == currentDayNb && currentRepasCategorie.Equals("Diner"))
                        {
                            x.Aliments.ForEach(async a =>
                            {
                                var lenght = a.Length;
                                var id = a[lenght - 1];
                                var aliment = await App.Client.GetAlimentAsync(id.ToString());
                                Aliment currentAliment = new Aliment() { AlimentName = aliment.AlimentName, Calorie = aliment.Calorie, Glucide = aliment.Glucide, Proteine = aliment.Proteine, Quantite = aliment.Quantite };
                                Diner.Add(currentAliment);
                            });
                        }
                        if (x.Jour == currentDayNb && currentRepasCategorie.Equals("Déjeuner"))
                        {
                            x.Aliments.ForEach(async a =>
                            {
                                var lenght = a.Length;
                                var id = a[lenght - 1];
                                var aliment = await App.Client.GetAlimentAsync(id.ToString());
                                Aliment currentAliment = new Aliment() { AlimentName = aliment.AlimentName, Calorie = aliment.Calorie, Glucide = aliment.Glucide, Proteine = aliment.Proteine, Quantite = aliment.Quantite };
                                Dejeuner.Add(currentAliment);
                            });
                        }
                        if (x.Jour == currentDayNb && currentRepasCategorie.Equals("Collation"))
                        {
                            List<Aliment> currentCollation = new List<Aliment>();
                            x.Aliments.ForEach(async a =>
                            {
                                var lenght = a.Length;
                                var id = a[lenght - 1];
                                var aliment = await App.Client.GetAlimentAsync(id.ToString());
                                Aliment currentAliment = new Aliment() { AlimentName = aliment.AlimentName, Calorie = aliment.Calorie, Glucide = aliment.Glucide, Proteine = aliment.Proteine, Quantite = aliment.Quantite };
                                currentCollation.Add(currentAliment);
                            });
                            Collation = currentCollation;
                        }

                    }
                }
               /* repas.ForEach(async (x) =>
                {
                    var repasCategorie = await App.Client.GetRepasCategorieAsync(x.Id);
                    if (repasCategorie.Counter > 0)
                    {
                        string currentRepasCategorie = repasCategorie.Liste[0].Libelle;
                        if (x.Jour == currentDayNb && currentRepasCategorie.Equals("Petit déjeuner"))
                        {
                            x.Aliments.ForEach(async a =>
                            {
                                var lenght = a.Length;
                                var id = a[lenght - 1];
                                var aliment = await App.Client.GetAlimentAsync(id.ToString());
                                Aliment currentAliment = new Aliment() { AlimentName = aliment.AlimentName, Calorie = aliment.Calorie, Glucide = aliment.Glucide, Proteine = aliment.Proteine, Quantite = aliment.Quantite };
                                PtiDej.Add(currentAliment);
                            });

                        }
                        if (x.Jour == currentDayNb && currentRepasCategorie.Equals("Diner"))
                        {
                            x.Aliments.ForEach(async a =>
                            {
                                var lenght = a.Length;
                                var id = a[lenght - 1];
                                var aliment = await App.Client.GetAlimentAsync(id.ToString());
                                Aliment currentAliment = new Aliment() { AlimentName = aliment.AlimentName, Calorie = aliment.Calorie, Glucide = aliment.Glucide, Proteine = aliment.Proteine, Quantite = aliment.Quantite };
                                Diner.Add(currentAliment);
                            });
                        }
                        if (x.Jour == currentDayNb && currentRepasCategorie.Equals("Déjeuner"))
                        {
                            x.Aliments.ForEach(async a =>
                            {
                                var lenght = a.Length;
                                var id = a[lenght - 1];
                                var aliment = await App.Client.GetAlimentAsync(id.ToString());
                                Aliment currentAliment = new Aliment() { AlimentName = aliment.AlimentName, Calorie = aliment.Calorie, Glucide = aliment.Glucide, Proteine = aliment.Proteine, Quantite = aliment.Quantite };
                                Dejeuner.Add(currentAliment);
                            });
                        }
                        if (x.Jour == currentDayNb && currentRepasCategorie.Equals("Collation"))
                        {
                            List<Aliment> currentCollation = new List<Aliment>();
                            x.Aliments.ForEach(async a =>
                            {
                                var lenght = a.Length;
                                var id = a[lenght - 1];
                                var aliment = await App.Client.GetAlimentAsync(id.ToString());
                                Aliment currentAliment = new Aliment() { AlimentName = aliment.AlimentName, Calorie = aliment.Calorie, Glucide = aliment.Glucide, Proteine = aliment.Proteine, Quantite = aliment.Quantite };
                                currentCollation.Add(currentAliment);
                            });
                            Collation = currentCollation;
                        }

                    }

                });*/
            }
        }




    }
}
