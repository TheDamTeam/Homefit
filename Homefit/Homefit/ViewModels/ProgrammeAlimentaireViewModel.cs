using Homefit.Models;
using Homefit.Services;
using Homefit.ViewModels.Base;
using Homefit.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Homefit.ViewModels
{
    public class ProgrammeAlimentaireViewModel : BaseViewModel
    {
        public INavigation Navigation { get; set; }
        ProgrammeNutrition currentProgramme;
        bool participe;
        int dayNumber;

        private int height;
        public int Height
        {
            get { return height; }
            set { SetProperty(ref height, value); }
        }
        //Utilisateur utilisateur = await App.DataBase.GetUtilisateurIsConnect();

        public ICommand GetProgramme1 => new Command<Days>(LoadDailyProgram);
        async void LoadDailyProgram(Days obj)
        {
            Utilisateur utilisateur = await App.DataBase.GetUtilisateurIsConnect();
            dayNumber = int.Parse(obj.day1.Split(' ')[1]);

            //participeProgramme();

            var apiResponse = await App.Client.GetUserProgNutritionAsync(utilisateur.Id);

            if (apiResponse.Counter > 0)
            {
                await Navigation.PushAsync(new ProgDayView(dayNumber));
            }
            else
            {
                await Navigation.PushAsync(new ParticpeProgView(dayNumber));
            }
            
        }
        public ICommand GetProgramme2 => new Command<Days>(LoadDailyProgram2);
        async void LoadDailyProgram2(Days obj)
        {
            Utilisateur utilisateur = await App.DataBase.GetUtilisateurIsConnect();
            int dayNumber = int.Parse(obj.day2.Split(' ')[1]);

            var apiResponse = await App.Client.GetUserProgNutritionAsync(utilisateur.Id);

            if (apiResponse.Counter > 0)
            {
                await Navigation.PushAsync(new ProgDayView(dayNumber));
            }
            else
            {
                await Navigation.PushAsync(new ParticpeProgView(dayNumber));
            }
        }
        public ICommand GetProgramme3 => new Command<Days>(LoadDailyProgram3);
        async void LoadDailyProgram3(Days obj)
        {
            Utilisateur utilisateur = await App.DataBase.GetUtilisateurIsConnect();
            int dayNumber = int.Parse(obj.day3.Split(' ')[1]);

            var apiResponse = await App.Client.GetUserProgNutritionAsync(utilisateur.Id);

            if (apiResponse.Counter > 0)
            {
                await Navigation.PushAsync(new ProgDayView(dayNumber));
            }
            else
            {
                await Navigation.PushAsync(new ParticpeProgView(dayNumber));
            }
        }

        List<Days> days = new List<Days>();
        public List<Days> ListDays
        {
            get { return days; }
            set 
            { 
                SetProperty(ref days, value);
                Height = (ListDays.Count * 50);
            }
        }
        public ProgrammeAlimentaireViewModel()
        {
            participe = false;
            ListDays = new List<Days>()
            {
                new Days("Jour 1","Jour 2","Jour 3"),
                new Days("Jour 4","Jour 5","Jour 6"),
                new Days("Jour 7","Jour 8","Jour 9"),
                new Days("Jour 10","Jour 11","Jour 12"),
                new Days("Jour 13","Jour 14","Jour 15"),
                new Days("Jour 16","Jour 17","Jour 18"),
                new Days("Jour 19","Jour 20","Jour 21"),
                new Days("Jour 22","Jour 23","Jour 24"),
                new Days("Jour 25","Jour 26","Jour 27"),
                new Days("Jour 28","Jour 29","Jour 30"),
            };
        }

        Days daysSelectec;

        public Days DaysSelected
        {
            get { return daysSelectec; }
            set
            {
                SetProperty(ref daysSelectec, value);
                if (value != null)
                {
                }
            }
        }

        public async void participeProgramme()
        {
            Utilisateur utilisateur = await App.DataBase.GetUtilisateurIsConnect();
            var apiResponse = await App.Client.GetParticipeProgNutritifAsync();
            if (apiResponse.Counter > 0)
            {
                var participes = apiResponse.Participe;
                participes.ForEach(async w =>
                {
                    var userUrlLength = w.Utilisateur.Length;
                    var userId = w.Utilisateur[userUrlLength - 1];
                    if (userId == utilisateur.Id)
                    {
                        this.participe = true;
                        var programmeId = w.Id;
                        var programme = await App.Client.GetProgNutritionAsync(programmeId);
                        currentProgramme = new ProgrammeNutrition() { Id = Int32.Parse(programme.Id), ProgrammeName = programme.ProgrammeName, };
                        await Navigation.PushAsync(new ProgDayView(dayNumber));
                    }
                });
            }
        }

        

    }
}
